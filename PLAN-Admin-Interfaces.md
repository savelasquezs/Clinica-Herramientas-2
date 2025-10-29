# Plan: Implementar Interfaces de Administración con Menú Lateral

## Objetivo

Crear todas las interfaces de administración (gestión de pacientes, citas y facturas) con un menú lateral centralizado en AdminMainForm para acceder a todas las funcionalidades. Diseño intermedio con colores del rol aplicados.

## Estructura de Archivos a Crear

```
Infrastructure/GUI/Admin/
├── AdminMainForm.cs (actualizar)
├── AdminMainForm.Designer.cs (actualizar)
├── Patients/
│   ├── PatientManagementForm.cs (nuevo)
│   ├── PatientManagementForm.Designer.cs (nuevo)
│   ├── PatientCreateForm.cs (nuevo)
│   ├── PatientCreateForm.Designer.cs (nuevo)
│   ├── PatientEditForm.cs (nuevo)
│   └── PatientEditForm.Designer.cs (nuevo)
├── Appointments/
│   ├── AppointmentManagementForm.cs (nuevo)
│   └── AppointmentManagementForm.Designer.cs (nuevo)
└── Invoices/
    ├── InvoiceManagementForm.cs (nuevo)
    └── InvoiceManagementForm.Designer.cs (nuevo)
```

## Parte 1: Actualizar AdminMainForm con Menú Lateral

### Modificar AdminMainForm.Designer.cs

Agregar:
- Panel lateral izquierdo (ancho 250px, color azul #2563eb)
- Panel de contenido principal (resto del espacio)
- Botones del menú lateral: "Gestión de Pacientes", "Citas Médicas", "Facturación"
- Botón "Cerrar Sesión" al final del panel lateral
- Labels de información del usuario en la parte superior del panel lateral

### Modificar AdminMainForm.cs

Agregar:
- Campo `private Form? currentChildForm;` para mantener referencia al formulario actual
- Método `OpenChildForm(Form childForm)` para abrir formularios en el panel de contenido
- Event handlers para cada botón del menú lateral
- Pasar `currentUser` y `AdminConfig` a los formularios hijos

## Parte 2: PatientManagementForm (Gestión de Pacientes)

### Crear PatientManagementForm.cs

Funcionalidad basada en `AdminUseCase` y `ViewPatientInformation`:
```csharp
- Constructor recibe: User currentUser, AdminConfig adminConfig
- Método LoadPatients() que usa ViewPatientInformationService.GetAllPatients()
- Botón "Nuevo Paciente" → Abre PatientCreateForm
- Botón "Editar" → Abre PatientEditForm con paciente seleccionado
- TextBox de búsqueda por DNI/nombre
- DataGridView para mostrar pacientes con columnas: DNI, Nombre, Email, Teléfono, Género
```

### Crear PatientManagementForm.Designer.cs

Componentes:
- Panel superior con título "Gestión de Pacientes"
- TextBox búsqueda + Button buscar
- DataGridView (Dock Fill)
- Panel inferior con botones: "Nuevo Paciente", "Editar", "Actualizar"
- Colores: Headers azul #2563eb, alternancia de filas

## Parte 3: PatientCreateForm (Crear Paciente)

### Crear PatientCreateForm.cs

Funcionalidad basada en `AdminUseCase.CreateNewPatient`:
```csharp
- Constructor recibe: AdminConfig adminConfig
- Validación de campos antes de guardar
- Método SavePatient() que llama AdminUseCase.CreateNewPatient() con todos los parámetros:
  * fullname, dni, email, phonenumber, birthdate, address, gender
  * emergencyFirstName, emergencyLastName, emergencyRelationship, emergencyPhone
  * insuranceCompanyName, insurancePolicyNumber, insuranceIsActive, insuranceExpirationDate
- Manejo de excepciones con MessageBox
```

### Crear PatientCreateForm.Designer.cs

Componentes organizados en GroupBoxes:
1. **Información Personal**:
   - TextBox: Nombre completo, DNI, Email, Teléfono, Dirección
   - DateTimePicker: Fecha de nacimiento
   - ComboBox: Género (Masculino, Femenino, Otro)

2. **Contacto de Emergencia**:
   - TextBox: Nombre, Apellido, Relación, Teléfono

3. **Seguro Médico**:
   - TextBox: Compañía, Número de póliza
   - CheckBox: Estado activo
   - DateTimePicker: Fecha de vencimiento

4. **Botones**: Guardar (azul #2563eb), Cancelar

## Parte 4: PatientEditForm (Editar Paciente)

### Crear PatientEditForm.cs

Funcionalidad basada en `AdminUseCase.UpdateExistingPatient`:
```csharp
- Constructor recibe: Patient patient, AdminConfig adminConfig
- Cargar datos actuales del paciente en los campos
- Campos editables: email, phone, address (según UpdateExistingPatient)
- Campos de solo lectura: DNI, nombre, fecha nacimiento, género
- Método SaveChanges() que llama AdminUseCase.UpdateExistingPatient()
```

### Crear PatientEditForm.Designer.cs

Componentes:
- Labels de solo lectura para: DNI, Nombre, Fecha nacimiento, Género
- TextBoxes editables para: Email, Teléfono, Dirección
- GroupBox "Contacto de Emergencia" (solo lectura)
- GroupBox "Seguro Médico" (solo lectura)
- Botones: Guardar, Cancelar

## Parte 5: AppointmentManagementForm (Gestión de Citas)

### Crear AppointmentManagementForm.cs

Funcionalidad basada en `AdminUseCase.CreateNewAppointment`:
```csharp
- Constructor recibe: User currentUser, AdminConfig adminConfig
- DataGridView con citas existentes (si hay método para listar)
- Formulario inline para crear nueva cita con campos:
  * ID de cita (int)
  * DNI del paciente (TextBox con validación)
  * Fecha y hora (DateTimePicker)
- Método CreateAppointment() que llama AdminUseCase.CreateNewAppointment(id, patientDni, date)
- Validación que el paciente existe
```

### Crear AppointmentManagementForm.Designer.cs

Componentes:
- Panel superior "Nueva Cita" con:
  - TextBox: ID de cita
  - TextBox: DNI del paciente
  - DateTimePicker: Fecha y hora
  - Button: "Crear Cita"
- DataGridView para mostrar citas (si disponible)
- Colores: Azul corporativo #2563eb

## Parte 6: InvoiceManagementForm (Gestión de Facturas)

### Crear InvoiceManagementForm.cs

Funcionalidad basada en `AdminUseCase.CreateNewInvoice` y `CreateInvoice.Create`:
```csharp
- Constructor recibe: User currentUser, AdminConfig adminConfig
- Formulario para crear factura con campos:
  * Número de factura (int) - Validar que sea único
  * DNI del paciente (TextBox con validación de existencia)
  * DNI del doctor (TextBox con validación que sea Doctor)
  * Números de órdenes (TextBox para ingresar números separados por comas, ej: "1,2,3")
  * Fecha de factura (DateTimePicker)
- Método CreateInvoice() que:
  1. Divide el string de números de órdenes en List<int>
  2. Llama AdminUseCase.CreateNewInvoice(invoiceNumber, patientDni, doctorDni, orderNumbers, invoiceDate)
  3. Esta llamada interna ejecuta la lógica completa:
     - Valida que paciente existe
     - Valida que doctor existe y tiene rol Doctor
     - Obtiene todas las órdenes por número
     - Crea la factura
     - Calcula totalAmount sumando todos los costs de los items de las órdenes
     - Calcula copago anual acumulado
     - Si la póliza está inactiva o vencida: Copago = Total, Seguro = 0
     - Si copago anual >= $1,000,000: Copago = 0, Seguro = Total
     - Si no: Copago = Min($50,000, Total), Seguro = Total - Copago
     - Actualiza copago anual acumulado
     - Guarda la factura
     - Retorna Invoice con todos los cálculos

- Mostrar resultado con:
  * Total de la factura (suma de costs de todos los items)
  * Copago a cargo del paciente
  * Monto cubierto por seguro
  * Copago anual acumulado
  * Información del paciente (nombre, seguro, póliza)
  * Información del doctor
- Panel de vista previa con todos los detalles antes de confirmar
- Validaciones antes de crear:
  - Número de factura único
  - Paciente existe
  - Doctor existe y es Doctor
  - Todas las órdenes existen
  - Todos los campos requeridos completos
```

### Crear InvoiceManagementForm.Designer.cs

Componentes:
- GroupBox "Nueva Factura" con:
  - TextBox: Número de factura
  - TextBox: DNI del paciente (con validación)
  - Label: Nombre del paciente (actualizado cuando se busca)
  - TextBox: DNI del doctor (con validación)
  - Label: Nombre del doctor (actualizado cuando se busca)
  - TextBox: Números de órdenes (separadas por comas)
  - DateTimePicker: Fecha de factura
  - Button: "Validar Órdenes" (verifica que todas existan)
  - Button: "Generar Factura"
  
- GroupBox "Vista Previa" con:
  - Label: Total de la factura
  - Label: Copago a cargo del paciente
  - Label: Monto cubierto por seguro
  - Label: Copago anual acumulado
  - GroupBox "Información del Paciente":
    - Label: Nombre, DNI, Email, Seguro
  - GroupBox "Información del Doctor":
    - Label: Nombre, DNI
  - GroupBox "Detalle de Órdenes":
    - DataGridView con: Número orden, Tipo item, Nombre, Costo

- DataGridView para facturas existentes con columnas:
  - Número factura
  - Paciente
  - Doctor
  - Fecha
  - Total
  - Copago
  - Seguro

## Diseño Visual Aplicado

### Colores Consistentes:
- Color principal: Azul corporativo #2563eb
- Color de fondo: Blanco #ffffff y gris claro #f8fafc
- Color de texto: Negro #000000 y gris oscuro #1f2937

### Estilos de Componentes:
- **Panels**: BackColor con color del rol, padding 10px
- **Buttons**: BackColor azul, ForeColor blanco, FlatStyle Flat, bordes redondeados (no nativo, simulado con padding)
- **DataGridView**: AlternatingRowsDefaultCellStyle con gris claro, ColumnHeadersDefaultCellStyle con azul
- **GroupBox**: Font bold para título, padding 10px
- **Labels de título**: Font Size 14-16, Bold
- **TextBox**: BorderStyle FixedSingle

## Integración con AdminConfig

Todos los formularios usan `AdminConfig` para acceder a:
- `AdminUseCase` para operaciones de negocio
- `ViewPatientInformationService` para consultas de pacientes
- `PatientBuilder`, `AppointmentBuilder`, `InvoiceBuilder` si se necesitan

## Manejo de Errores

Patrón consistente en todos los formularios:
```csharp
try 
{
    // Operación del UseCase
    MessageBox.Show("Operación exitosa", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
}
catch (Exception ex)
{
    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
```

## Orden de Implementación Sugerido

1. Actualizar AdminMainForm con menú lateral
2. PatientManagementForm (lista básica)
3. PatientCreateForm (crear pacientes)
4. PatientEditForm (editar pacientes)
5. AppointmentManagementForm (gestión de citas)
6. InvoiceManagementForm (gestión de facturas)

## Notas Importantes

- Todos los formularios se abren en el panel de contenido de AdminMainForm (no como nuevas ventanas)
- Se mantiene la referencia al usuario actual y config en todos los formularios
- La validación se hace antes de llamar a los UseCases
- Los formularios hijos se cierran cuando se selecciona otra opción del menú
- El diseño es intermedio: colores aplicados pero sin efectos complejos como sombras o animaciones
