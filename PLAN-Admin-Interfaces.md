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

Funcionalidad basada en `AdminUseCase.CreateNewInvoice`:
```csharp
- Constructor recibe: User currentUser, AdminConfig adminConfig
- Formulario para crear factura con campos:
  * Número de factura (int)
  * DNI del paciente (TextBox)
  * DNI del doctor (TextBox)
  * Números de órdenes (TextBox para lista separada por comas)
  * Fecha de factura (DateTimePicker)
- Método CreateInvoice() que llama AdminUseCase.CreateNewInvoice()
- Mostrar resultado con detalles de copago y seguro
- Panel de vista previa con información calculada
```

### Crear InvoiceManagementForm.Designer.cs

Componentes:
- GroupBox "Nueva Factura" con:
  - TextBox: Número de factura, DNI paciente, DNI doctor, Números de órdenes
  - DateTimePicker: Fecha de factura
  - Button: "Generar Factura"
- GroupBox "Vista Previa" con:
  - Labels para mostrar: Total, Copago, Monto Seguro, Copago Anual Acumulado
- DataGridView para facturas existentes (si disponible)

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
