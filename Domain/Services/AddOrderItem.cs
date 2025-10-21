using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Domain.Ports;

namespace Clinica_Herramientas_2.Domain.Services
{
    public class AddOrderItem(IOrderPort orderPort, IInventoryPort inventoryPort, OrderRulesService orderRulesService)
    {
        private readonly IOrderPort orderPort = orderPort;
        private readonly IInventoryPort inventoryPort = inventoryPort;
        private readonly OrderRulesService orderRulesService = orderRulesService;

        public void AddItem(CreateOrderItemDTO dto)
        {
            ArgumentNullException.ThrowIfNull(dto);

            // Validar que la orden existe
            var order = orderPort.FindByNumber(dto.OrderNumber) ?? throw new Exception("La orden no existe.");

            // Crear el OrderItem usando el servicio existente
            var createOrderItemService = new CreateOrderItem(orderPort, inventoryPort);
            var newItem = createOrderItemService.Create(dto);

            // Agregar el ítem a la orden
            order.AddItem(newItem);

            // Validar reglas cross-item después de agregar
            OrderRulesService.ValidateOrder(order);

            // Actualizar la orden en la base de datos
            orderPort.Update(order);
        }
    }
}
