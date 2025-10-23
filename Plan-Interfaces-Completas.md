# Plan: Desarrollo Completo de Interfaces para Sistema de Clínica

## Objetivo
Crear todas las interfaces necesarias para plasmar la funcionalidad completa del sistema de gestión de clínica, basándose en los UseCases y modelos existentes, con diseño moderno y atractivo.

## Análisis de Funcionalidad Existente

### Funcionalidades por Rol Identificadas:

**🔵 ADMIN (AdminUseCase)**:
- Crear pacientes (con contacto de emergencia y seguro médico)
- Actualizar información de pacientes
- Crear citas médicas
- Crear facturas (con cálculos de copago y seguro)

**🟢 DOCTOR (DoctorUseCase)**:
- Crear órdenes médicas
- Agregar medicamentos a órdenes
- Agregar procedimientos a órdenes
- Agregar ayudas diagnósticas a órdenes
- Crear historiales médicos
- Ver historial médico de pacientes

**🩷 NURSE (NurseUseCase)**:
- Crear visitas de enfermería
- Registrar signos vitales
- Registrar medicamentos administrados
- Crear datos vitales

**🟣 RRHH (RRHHUseCase)**:
- Crear usuarios del sistema
- Actualizar usuarios existentes
- Eliminar usuarios

**🟠 SUPPORT (SupportUseCase)**:
- Crear medicamentos
- Actualizar medicamentos
- Crear procedimientos
- Actualizar procedimientos
- Crear ayudas diagnósticas
- Actualizar ayudas diagnósticas
- Listar todos los recursos clínicos

## Plan de Desarrollo de Interfaces

### FASE 1: Interfaces de Administración (Admin)

#### 1.1 PatientManagementForm
**Ubicación**: `Infrastructure/GUI/Admin/Patients/PatientManagementForm.cs`

**Funcionalidades**:
- **Lista de pacientes** con DataGridView moderno
- **Búsqueda** por DNI, nombre, email
- **Filtros** por género, edad, seguro médico
- **Botones de acción**: Ver, Editar, Eliminar
- **Botón "Nuevo Paciente"** → Abre PatientCreateForm

**Diseño**:
- Card principal con fondo azul corporativo (#2563eb)
- DataGridView con alternancia de colores
- Barra de búsqueda con iconos
- Botones con efectos hover

#### 1.2 PatientCreateForm
**Ubicación**: `Infrastructure/GUI/Admin/Patients/PatientCreateForm.cs`

**Funcionalidades** (basado en AdminUseCase.CreateNewPatient):
- **Información Personal**: Nombre completo, DNI, email, teléfono, fecha nacimiento, dirección, género
- **Contacto de Emergencia**: Nombre, apellido, relación, teléfono
- **Seguro Médico**: Compañía, número de póliza, estado activo, fecha de vencimiento
- **Validación** en tiempo real
- **Botones**: Guardar, Cancelar

**Diseño**:
- Formulario multi-sección con pestañas
- Validación visual con colores
- Campos organizados por grupos
- Iconos para cada sección

#### 1.3 PatientEditForm
**Ubicación**: `Infrastructure/GUI/Admin/Patients/PatientEditForm.cs`

**Funcionalidades** (basado en AdminUseCase.UpdateExistingPatient):
- **Campos editables**: Email, teléfono, dirección
- **Información de solo lectura**: DNI, nombre, fecha nacimiento
- **Historial de cambios**
- **Botones**: Guardar, Cancelar

#### 1.4 AppointmentManagementForm
**Ubicación**: `Infrastructure/GUI/Admin/Appointments/AppointmentManagementForm.cs`

**Funcionalidades** (basado en AdminUseCase.CreateNewAppointment):
- **Lista de citas** con calendario
- **Crear nueva cita**: ID, paciente (por DNI), fecha
- **Filtros** por fecha, paciente, estado
- **Vista de calendario** mensual
- **Botones**: Nueva Cita, Editar, Cancelar

#### 1.5 InvoiceManagementForm
**Ubicación**: `Infrastructure/GUI/Admin/Invoices/InvoiceManagementForm.cs`

**Funcionalidades** (basado en AdminUseCase.CreateNewInvoice):
- **Lista de facturas** existentes
- **Crear nueva factura**: Número, paciente, doctor, órdenes, fecha
- **Cálculo automático** de copago y seguro
- **Vista previa** de factura
- **Imprimir** factura
- **Botones**: Nueva Factura, Imprimir, Exportar

### FASE 2: Interfaces de Doctor

#### 2.1 OrderManagementForm
**Ubicación**: `Infrastructure/GUI/Doctor/Orders/OrderManagementForm.cs`

**Funcionalidades** (basado en DoctorUseCase):
- **Lista de órdenes** del doctor
- **Crear nueva orden**: Número de orden, fecha de creación
- **Agregar items** a órdenes existentes
- **Estados**: Borrador, Enviada, Procesada
- **Botones**: Nueva Orden, Agregar Item, Enviar

#### 2.2 OrderItemForm
**Ubicación**: `Infrastructure/GUI/Doctor/Orders/OrderItemForm.cs`

**Funcionalidades** (basado en DoctorUseCase métodos Add*):
- **Seleccionar tipo**: Medicamento, Procedimiento, Ayuda Diagnóstica
- **Medicamentos**: Seleccionar medicamento, dosis, duración del tratamiento
- **Procedimientos**: Seleccionar procedimiento, frecuencia, especialista requerido
- **Ayudas Diagnósticas**: Seleccionar ayuda, cantidad, especialista requerido
- **Costo automático** basado en inventario
- **Botones**: Agregar, Cancelar

#### 2.3 MedicalRecordForm
**Ubicación**: `Infrastructure/GUI/Doctor/MedicalRecords/MedicalRecordForm.cs`

**Funcionalidades** (basado en DoctorUseCase.CreateNewMedicalRecord):
- **Información básica**: Fecha, paciente, motivo de consulta
- **Sintomatología**: Campo de texto libre
- **Diagnóstico**: Campo de texto libre
- **Orden asociada**: Seleccionar orden existente
- **Botones**: Guardar, Cancelar

#### 2.4 MedicalHistoryForm
**Ubicación**: `Infrastructure/GUI/Doctor/MedicalRecords/MedicalHistoryForm.cs`

**Funcionalidades** (basado en DoctorUseCase.GetMedicalHistory):
- **Búsqueda por DNI** del paciente
- **Lista de historiales** ordenados por fecha
- **Vista detallada** de cada historial
- **Filtros** por fecha, diagnóstico
- **Botones**: Buscar, Ver Detalle, Exportar

### FASE 3: Interfaces de Enfermería

#### 3.1 NurseVisitForm
**Ubicación**: `Infrastructure/GUI/Nurse/Visits/NurseVisitForm.cs`

**Funcionalidades** (basado en NurseUseCase.CreateNewNurseVisit):
- **Información de visita**: Orden item, pruebas realizadas, notas, fecha
- **Signos vitales**: Presión arterial, temperatura, pulso, nivel de oxígeno
- **Medicamentos administrados**: Lista de medicamentos con dosis y vía
- **Paciente**: Seleccionar paciente
- **Botones**: Guardar, Cancelar

#### 3.2 VitalSignsForm
**Ubicación**: `Infrastructure/GUI/Nurse/Visits/VitalSignsForm.cs`

**Funcionalidades** (basado en NurseUseCase.CreateVitalData):
- **Presión arterial**: Campo de texto
- **Temperatura**: Campo numérico
- **Pulso**: Campo numérico
- **Nivel de oxígeno**: Campo numérico
- **Validación** de rangos normales
- **Botones**: Guardar, Cancelar

#### 3.3 AdministeredMedicationForm
**Ubicación**: `Infrastructure/GUI/Nurse/Visits/AdministeredMedicationForm.cs`

**Funcionalidades** (basado en NurseUseCase.CreateAdministeredMedication):
- **Medicamento**: Seleccionar del inventario
- **Dosis**: Campo de texto
- **Vía de administración**: Dropdown
- **Orden item**: Seleccionar orden item
- **Botones**: Agregar, Cancelar

### FASE 4: Interfaces de RRHH

#### 4.1 UserManagementForm
**Ubicación**: `Infrastructure/GUI/RRHH/Users/UserManagementForm.cs`

**Funcionalidades** (basado en RRHHUseCase):
- **Lista de usuarios** del sistema
- **Búsqueda** por nombre, DNI, rol
- **Filtros** por rol, estado activo
- **Botones de acción**: Ver, Editar, Eliminar
- **Botón "Nuevo Usuario"** → Abre UserCreateForm

#### 4.2 UserCreateForm
**Ubicación**: `Infrastructure/GUI/RRHH/Users/UserCreateForm.cs`

**Funcionalidades** (basado en RRHHUseCase.CreateNewUser):
- **Información Personal**: Nombre completo, DNI, email, teléfono, fecha nacimiento, dirección
- **Credenciales**: Username, password
- **Rol**: Dropdown con opciones (Admin, Doctor, Nurse, RRHH, Support)
- **Validación** de username único
- **Botones**: Crear, Cancelar

#### 4.3 UserEditForm
**Ubicación**: `Infrastructure/GUI/RRHH/Users/UserEditForm.cs`

**Funcionalidades** (basado en RRHHUseCase.UpdateExistingUser):
- **Campos editables**: Nombre completo, email, teléfono, dirección
- **Información de solo lectura**: DNI, username, rol
- **Botones**: Guardar, Cancelar

### FASE 5: Interfaces de Soporte

#### 5.1 InventoryManagementForm
**Ubicación**: `Infrastructure/GUI/Support/Inventory/InventoryManagementForm.cs`

**Funcionalidades** (basado en SupportUseCase):
- **Pestañas**: Medicamentos, Procedimientos, Ayudas Diagnósticas
- **Lista de recursos** por categoría
- **Búsqueda** por nombre, costo
- **Botones de acción**: Ver, Editar, Eliminar
- **Botones "Nuevo"** por categoría

#### 5.2 MedicationForm
**Ubicación**: `Infrastructure/GUI/Support/Inventory/MedicationForm.cs`

**Funcionalidades** (basado en SupportUseCase.CreateMedication):
- **Información**: ID, nombre, costo, dosis por defecto, duración del tratamiento
- **Validación** de campos numéricos
- **Botones**: Guardar, Cancelar

#### 5.3 ProcedureForm
**Ubicación**: `Infrastructure/GUI/Support/Inventory/ProcedureForm.cs`

**Funcionalidades** (basado en SupportUseCase.CreateProcedure):
- **Información**: ID, nombre, costo, frecuencia, requiere especialista, tipo de especialista
- **Checkbox** para especialista requerido
- **Dropdown** de tipos de especialista
- **Botones**: Guardar, Cancelar

#### 5.4 DiagnosticAidForm
**Ubicación**: `Infrastructure/GUI/Support/Inventory/DiagnosticAidForm.cs`

**Funcionalidades** (basado en SupportUseCase.CreateDiagnosticAid):
- **Información**: ID, nombre, costo, cantidad, requiere especialista, tipo de especialista
- **Checkbox** para especialista requerido
- **Dropdown** de tipos de especialista
- **Botones**: Guardar, Cancelar

### FASE 6: Interfaces Comunes

#### 6.1 PatientSearchForm
**Ubicación**: `Infrastructure/GUI/Common/PatientSearchForm.cs`

**Funcionalidades**:
- **Búsqueda** por DNI, nombre, email
- **Resultados** en lista
- **Selección** de paciente
- **Botones**: Buscar, Seleccionar, Cancelar

#### 6.2 OrderSearchForm
**Ubicación**: `Infrastructure/GUI/Common/OrderSearchForm.cs`

**Funcionalidades**:
- **Búsqueda** por número de orden, paciente, doctor
- **Filtros** por fecha, estado
- **Resultados** en lista
- **Botones**: Buscar, Seleccionar, Cancelar

#### 6.3 ResourceSearchForm
**Ubicación**: `Infrastructure/GUI/Common/ResourceSearchForm.cs`

**Funcionalidades**:
- **Búsqueda** por nombre, tipo, costo
- **Filtros** por categoría
- **Resultados** en lista
- **Botones**: Buscar, Seleccionar, Cancelar

## Patrones de Diseño Visual

### Paleta de Colores por Rol:
- **Admin**: Azul corporativo (#2563eb) + Blanco (#ffffff) + Gris claro (#f8fafc)
- **Doctor**: Verde médico (#059669) + Blanco (#ffffff) + Verde claro (#f0fdf4)
- **Nurse**: Rosa enfermería (#ec4899) + Blanco (#ffffff) + Rosa claro (#fdf2f8)
- **RRHH**: Púrpura RRHH (#7c3aed) + Blanco (#ffffff) + Púrpura claro (#faf5ff)
- **Support**: Naranja soporte (#ea580c) + Blanco (#ffffff) + Naranja claro (#fff7ed)

### Componentes Visuales Comunes:
- **Cards principales**: Fondo de color del rol, texto blanco, bordes redondeados
- **DataGridViews**: Alternancia de colores, headers con color del rol
- **Formularios**: Campos organizados en grupos, validación visual
- **Botones**: Estilo moderno con efectos hover, iconos FontAwesome
- **Búsquedas**: Campos con iconos, resultados destacados

### Elementos de Diseño:
- **Sombras**: Suaves para profundidad
- **Bordes**: Redondeados para modernidad
- **Espaciado**: Consistente y profesional
- **Tipografía**: Jerarquía clara con diferentes tamaños
- **Iconos**: FontAwesome para consistencia visual

## Cronograma de Implementación

### Semana 1-2: Fase 1 (Interfaces Admin)
- PatientManagementForm, PatientCreateForm, PatientEditForm
- AppointmentManagementForm, InvoiceManagementForm

### Semana 3-4: Fase 2 (Interfaces Doctor)
- OrderManagementForm, OrderItemForm
- MedicalRecordForm, MedicalHistoryForm

### Semana 5-6: Fase 3 (Interfaces Nurse)
- NurseVisitForm, VitalSignsForm, AdministeredMedicationForm

### Semana 7-8: Fase 4 (Interfaces RRHH)
- UserManagementForm, UserCreateForm, UserEditForm

### Semana 9-10: Fase 5 (Interfaces Support)
- InventoryManagementForm, MedicationForm, ProcedureForm, DiagnosticAidForm

### Semana 11-12: Fase 6 (Interfaces Comunes)
- PatientSearchForm, OrderSearchForm, ResourceSearchForm

## Notas Técnicas

### Estructura de Archivos:
```
Infrastructure/GUI/
├── Common/           # Formularios compartidos
├── Auth/             # Autenticación (ya existe)
├── Admin/            # Funcionalidades de Admin
│   ├── Patients/     # Gestión de pacientes
│   ├── Appointments/ # Gestión de citas
│   └── Invoices/     # Gestión de facturas
├── Doctor/           # Funcionalidades de Doctor
│   ├── Orders/       # Órdenes médicas
│   └── MedicalRecords/ # Historiales médicos
├── Nurse/            # Funcionalidades de Enfermería
│   └── Visits/       # Visitas de enfermería
├── RRHH/             # Funcionalidades de RRHH
│   └── Users/        # Gestión de usuarios
└── Support/          # Funcionalidades de Soporte
    └── Inventory/    # Gestión de inventario
```

### Patrones de Código:
- Cada formulario tendrá su propio archivo .cs y .Designer.cs
- Uso de UserControls para componentes reutilizables
- Implementación de interfaces para formularios similares
- Validación centralizada
- Manejo de errores consistente

### Integración con UseCases:
- Cada formulario se conectará directamente con su UseCase correspondiente
- Validación de permisos por rol
- Manejo de excepciones y errores
- Actualización de datos en tiempo real

Este plan proporciona una hoja de ruta completa para desarrollar todas las interfaces necesarias, basándose únicamente en la funcionalidad existente del sistema, con diseño moderno y atractivo.
