using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Clinica_Herramientas_2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clinical_resource",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    cost = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clinical_resource", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    order_number = table.Column<int>(type: "integer", nullable: false),
                    creation_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.order_number);
                });

            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    dni = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    fullname = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    phonenumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    birthdate = table.Column<DateOnly>(type: "date", nullable: false),
                    address = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.dni);
                });

            migrationBuilder.CreateTable(
                name: "diagnostic_aid",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    requires_specialist = table.Column<bool>(type: "boolean", nullable: false),
                    specialist_type_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diagnostic_aid", x => x.id);
                    table.ForeignKey(
                        name: "FK_diagnostic_aid_clinical_resource_id",
                        column: x => x.id,
                        principalTable: "clinical_resource",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "medication",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    dose = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    treatment_duration = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medication", x => x.id);
                    table.ForeignKey(
                        name: "FK_medication_clinical_resource_id",
                        column: x => x.id,
                        principalTable: "clinical_resource",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "procedure",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    frequency = table.Column<int>(type: "integer", nullable: false),
                    requires_specialist = table.Column<bool>(type: "boolean", nullable: false),
                    specialist_type_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_procedure", x => x.id);
                    table.ForeignKey(
                        name: "FK_procedure_clinical_resource_id",
                        column: x => x.id,
                        principalTable: "clinical_resource",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_item",
                columns: table => new
                {
                    order_number = table.Column<int>(type: "integer", nullable: false),
                    item_number = table.Column<int>(type: "integer", nullable: false),
                    cost = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    order_number1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_item", x => new { x.order_number, x.item_number });
                    table.ForeignKey(
                        name: "FK_order_item_order_order_number1",
                        column: x => x.order_number1,
                        principalTable: "order",
                        principalColumn: "order_number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "patient",
                columns: table => new
                {
                    dni = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    emergency_contact_first_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    emergency_contact_last_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    emergency_contact_relationship = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    emergency_contact_phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient", x => x.dni);
                    table.ForeignKey(
                        name: "FK_patient_person_dni",
                        column: x => x.dni,
                        principalTable: "person",
                        principalColumn: "dni",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    dni = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    role = table.Column<string>(type: "text", nullable: false),
                    username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.dni);
                    table.ForeignKey(
                        name: "FK_user_person_dni",
                        column: x => x.dni,
                        principalTable: "person",
                        principalColumn: "dni",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "diagnostic_aid_order_item",
                columns: table => new
                {
                    order_number = table.Column<int>(type: "integer", nullable: false),
                    item_number = table.Column<int>(type: "integer", nullable: false),
                    diagnostic_aid_id = table.Column<int>(type: "integer", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    requires_specialist = table.Column<bool>(type: "boolean", nullable: false),
                    specialist_type_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diagnostic_aid_order_item", x => new { x.order_number, x.item_number });
                    table.ForeignKey(
                        name: "FK_diagnostic_aid_order_item_diagnostic_aid_diagnostic_aid_id",
                        column: x => x.diagnostic_aid_id,
                        principalTable: "diagnostic_aid",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_diagnostic_aid_order_item_order_item_order_number_item_numb~",
                        columns: x => new { x.order_number, x.item_number },
                        principalTable: "order_item",
                        principalColumns: new[] { "order_number", "item_number" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "medication_order_item",
                columns: table => new
                {
                    order_number = table.Column<int>(type: "integer", nullable: false),
                    item_number = table.Column<int>(type: "integer", nullable: false),
                    medication_id = table.Column<int>(type: "integer", nullable: false),
                    dose = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    treatment_duration = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medication_order_item", x => new { x.order_number, x.item_number });
                    table.ForeignKey(
                        name: "FK_medication_order_item_medication_medication_id",
                        column: x => x.medication_id,
                        principalTable: "medication",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_medication_order_item_order_item_order_number_item_number",
                        columns: x => new { x.order_number, x.item_number },
                        principalTable: "order_item",
                        principalColumns: new[] { "order_number", "item_number" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "patient_care_record",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order_number = table.Column<int>(type: "integer", nullable: false),
                    item_number = table.Column<int>(type: "integer", nullable: false),
                    TestsPerformed = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Notes = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    PerformedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient_care_record", x => x.id);
                    table.ForeignKey(
                        name: "FK_patient_care_record_order_item_order_number_item_number",
                        columns: x => new { x.order_number, x.item_number },
                        principalTable: "order_item",
                        principalColumns: new[] { "order_number", "item_number" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "procedure_order_item",
                columns: table => new
                {
                    order_number = table.Column<int>(type: "integer", nullable: false),
                    item_number = table.Column<int>(type: "integer", nullable: false),
                    procedure_id = table.Column<int>(type: "integer", nullable: false),
                    frequency = table.Column<int>(type: "integer", nullable: false),
                    requires_specialist = table.Column<bool>(type: "boolean", nullable: false),
                    specialist_type_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_procedure_order_item", x => new { x.order_number, x.item_number });
                    table.ForeignKey(
                        name: "FK_procedure_order_item_order_item_order_number_item_number",
                        columns: x => new { x.order_number, x.item_number },
                        principalTable: "order_item",
                        principalColumns: new[] { "order_number", "item_number" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_procedure_order_item_procedure_procedure_id",
                        column: x => x.procedure_id,
                        principalTable: "procedure",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "appointment",
                columns: table => new
                {
                    id1 = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    date1 = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    patient_dni = table.Column<string>(type: "character varying(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointment", x => x.id1);
                    table.ForeignKey(
                        name: "FK_appointment_patient_patient_dni",
                        column: x => x.patient_dni,
                        principalTable: "patient",
                        principalColumn: "dni",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "health_insurance",
                columns: table => new
                {
                    PatientDni = table.Column<string>(type: "character varying(20)", nullable: false),
                    health_insurance_company = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    health_insurance_policy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    health_insurance_active = table.Column<bool>(type: "boolean", nullable: false),
                    health_insurance_expiration = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_health_insurance", x => x.PatientDni);
                    table.ForeignKey(
                        name: "FK_health_insurance_patient_PatientDni",
                        column: x => x.PatientDni,
                        principalTable: "patient",
                        principalColumn: "dni",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "invoice",
                columns: table => new
                {
                    invoice_number = table.Column<int>(type: "integer", nullable: false),
                    invoice_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    patient_dni = table.Column<string>(type: "character varying(20)", nullable: false),
                    doctor_dni = table.Column<string>(type: "character varying(20)", nullable: false),
                    total_amount = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    copayment_amount = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    insurance_amount = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    annual_copayment_accumulated = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoice", x => x.invoice_number);
                    table.ForeignKey(
                        name: "FK_invoice_patient_patient_dni",
                        column: x => x.patient_dni,
                        principalTable: "patient",
                        principalColumn: "dni",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_invoice_user_doctor_dni",
                        column: x => x.doctor_dni,
                        principalTable: "user",
                        principalColumn: "dni",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "medical_record",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    consultation_reason = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    symptoms = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    diagnosis = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    patient_dni = table.Column<string>(type: "character varying(20)", nullable: false),
                    doctor_dni = table.Column<string>(type: "character varying(20)", nullable: false),
                    order_number = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medical_record", x => x.id);
                    table.ForeignKey(
                        name: "FK_medical_record_order_order_number",
                        column: x => x.order_number,
                        principalTable: "order",
                        principalColumn: "order_number",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_medical_record_patient_patient_dni",
                        column: x => x.patient_dni,
                        principalTable: "patient",
                        principalColumn: "dni",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_medical_record_user_doctor_dni",
                        column: x => x.doctor_dni,
                        principalTable: "user",
                        principalColumn: "dni",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "performed_procedure",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_performed_procedure", x => x.id);
                    table.ForeignKey(
                        name: "FK_performed_procedure_patient_care_record_id",
                        column: x => x.id,
                        principalTable: "patient_care_record",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "invoice_order",
                columns: table => new
                {
                    InvoiceNumber = table.Column<int>(type: "integer", nullable: false),
                    OrdersOrderNumber = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoice_order", x => new { x.InvoiceNumber, x.OrdersOrderNumber });
                    table.ForeignKey(
                        name: "FK_invoice_order_invoice_InvoiceNumber",
                        column: x => x.InvoiceNumber,
                        principalTable: "invoice",
                        principalColumn: "invoice_number",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_invoice_order_order_OrdersOrderNumber",
                        column: x => x.OrdersOrderNumber,
                        principalTable: "order",
                        principalColumn: "order_number",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nurse_visit",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    visit_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    patient_dni = table.Column<string>(type: "character varying(20)", nullable: false),
                    nurse_dni = table.Column<string>(type: "character varying(20)", nullable: false),
                    vital_blood_pressure = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    vital_temperature = table.Column<double>(type: "double precision", nullable: false),
                    vital_pulse = table.Column<int>(type: "integer", nullable: false),
                    vital_oxygen_level = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nurse_visit", x => x.id);
                    table.ForeignKey(
                        name: "FK_nurse_visit_patient_patient_dni",
                        column: x => x.patient_dni,
                        principalTable: "patient",
                        principalColumn: "dni",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_nurse_visit_performed_procedure_id",
                        column: x => x.id,
                        principalTable: "performed_procedure",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_nurse_visit_user_nurse_dni",
                        column: x => x.nurse_dni,
                        principalTable: "user",
                        principalColumn: "dni",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "administered_medication",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    medication_id = table.Column<int>(type: "integer", nullable: false),
                    dose = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    administration_route = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    nurse_visit_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_administered_medication", x => x.id);
                    table.ForeignKey(
                        name: "FK_administered_medication_medication_medication_id",
                        column: x => x.medication_id,
                        principalTable: "medication",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_administered_medication_nurse_visit_nurse_visit_id",
                        column: x => x.nurse_visit_id,
                        principalTable: "nurse_visit",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_administered_medication_patient_care_record_id",
                        column: x => x.id,
                        principalTable: "patient_care_record",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_administered_medication_medication_id",
                table: "administered_medication",
                column: "medication_id");

            migrationBuilder.CreateIndex(
                name: "IX_administered_medication_nurse_visit_id",
                table: "administered_medication",
                column: "nurse_visit_id");

            migrationBuilder.CreateIndex(
                name: "IX_appointment_patient_dni",
                table: "appointment",
                column: "patient_dni");

            migrationBuilder.CreateIndex(
                name: "IX_diagnostic_aid_order_item_diagnostic_aid_id",
                table: "diagnostic_aid_order_item",
                column: "diagnostic_aid_id");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_doctor_dni",
                table: "invoice",
                column: "doctor_dni");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_patient_dni",
                table: "invoice",
                column: "patient_dni");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_order_OrdersOrderNumber",
                table: "invoice_order",
                column: "OrdersOrderNumber");

            migrationBuilder.CreateIndex(
                name: "IX_medical_record_doctor_dni",
                table: "medical_record",
                column: "doctor_dni");

            migrationBuilder.CreateIndex(
                name: "IX_medical_record_order_number",
                table: "medical_record",
                column: "order_number");

            migrationBuilder.CreateIndex(
                name: "IX_medical_record_patient_dni",
                table: "medical_record",
                column: "patient_dni");

            migrationBuilder.CreateIndex(
                name: "IX_medication_order_item_medication_id",
                table: "medication_order_item",
                column: "medication_id");

            migrationBuilder.CreateIndex(
                name: "IX_nurse_visit_nurse_dni",
                table: "nurse_visit",
                column: "nurse_dni");

            migrationBuilder.CreateIndex(
                name: "IX_nurse_visit_patient_dni",
                table: "nurse_visit",
                column: "patient_dni");

            migrationBuilder.CreateIndex(
                name: "IX_order_item_order_number1",
                table: "order_item",
                column: "order_number1");

            migrationBuilder.CreateIndex(
                name: "IX_patient_care_record_order_number_item_number",
                table: "patient_care_record",
                columns: new[] { "order_number", "item_number" });

            migrationBuilder.CreateIndex(
                name: "IX_person_email",
                table: "person",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_procedure_order_item_procedure_id",
                table: "procedure_order_item",
                column: "procedure_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_username",
                table: "user",
                column: "username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "administered_medication");

            migrationBuilder.DropTable(
                name: "appointment");

            migrationBuilder.DropTable(
                name: "diagnostic_aid_order_item");

            migrationBuilder.DropTable(
                name: "health_insurance");

            migrationBuilder.DropTable(
                name: "invoice_order");

            migrationBuilder.DropTable(
                name: "medical_record");

            migrationBuilder.DropTable(
                name: "medication_order_item");

            migrationBuilder.DropTable(
                name: "procedure_order_item");

            migrationBuilder.DropTable(
                name: "nurse_visit");

            migrationBuilder.DropTable(
                name: "diagnostic_aid");

            migrationBuilder.DropTable(
                name: "invoice");

            migrationBuilder.DropTable(
                name: "medication");

            migrationBuilder.DropTable(
                name: "procedure");

            migrationBuilder.DropTable(
                name: "performed_procedure");

            migrationBuilder.DropTable(
                name: "patient");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "clinical_resource");

            migrationBuilder.DropTable(
                name: "patient_care_record");

            migrationBuilder.DropTable(
                name: "person");

            migrationBuilder.DropTable(
                name: "order_item");

            migrationBuilder.DropTable(
                name: "order");
        }
    }
}
