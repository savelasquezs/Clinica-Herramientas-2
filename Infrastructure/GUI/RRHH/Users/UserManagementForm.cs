using Clinica_Herramientas_2.Domain.Model;
using Clinica_Herramientas_2.Application.Adapters.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Clinica_Herramientas_2.Infrastructure.GUI.RRHH.Users
{
    public partial class UserManagementForm : Form
    {
        private readonly User currentUser;
        private readonly RRHHInputs rrhhInputs;
        private List<User> users = new List<User>();

        public UserManagementForm(RRHHInputs rrhhInputs, User currentUser)
        {
            this.currentUser = currentUser;
            this.rrhhInputs = rrhhInputs;
            InitializeComponent();
            SetupDataGridView();
            LoadUsers();
            // Establecer el usuario actual en el use case
            rrhhInputs.SetCurrentUser(currentUser);
        }

        private void SetupDataGridView()
        {
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.Columns.Clear();

            // Configurar estilos
            var headerStyle = new DataGridViewCellStyle
            {
                BackColor = System.Drawing.Color.FromArgb(124, 58, 237),
                ForeColor = System.Drawing.Color.White,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold)
            };
            dgvUsers.ColumnHeadersDefaultCellStyle = headerStyle;

            var alternatingRowStyle = new DataGridViewCellStyle
            {
                BackColor = System.Drawing.Color.FromArgb(250, 245, 255)
            };
            dgvUsers.AlternatingRowsDefaultCellStyle = alternatingRowStyle;

            // Agregar columnas
            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDni",
                HeaderText = "DNI",
                DataPropertyName = "Dni",
                Width = 120
            });

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colFullname",
                HeaderText = "Nombre Completo",
                DataPropertyName = "Fullname",
                Width = 250,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEmail",
                HeaderText = "Email",
                DataPropertyName = "Email",
                Width = 200
            });

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colUsername",
                HeaderText = "Usuario",
                DataPropertyName = "Username",
                Width = 120
            });

            dgvUsers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colRole",
                HeaderText = "Rol",
                DataPropertyName = "Role",
                Width = 120
            });
        }

        private void LoadUsers()
        {
            try
            {
                users = rrhhInputs.GetAllUsers();
                dgvUsers.DataSource = null;
                dgvUsers.DataSource = users;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var searchTerm = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadUsers();
                return;
            }

            var filteredUsers = users.Where(u =>
                u.Dni.ToLower().Contains(searchTerm) ||
                u.Fullname.ToLower().Contains(searchTerm) ||
                u.Email.ToLower().Contains(searchTerm) ||
                u.Username.ToLower().Contains(searchTerm)
            ).ToList();

            dgvUsers.DataSource = null;
            dgvUsers.DataSource = filteredUsers;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                var createForm = new UserCreateForm(rrhhInputs, currentUser);
                if (createForm.ShowDialog() == DialogResult.OK)
                {
                    LoadUsers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear usuario: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un usuario para editar", "Información", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                MessageBox.Show("Funcionalidad de editar usuario - Próximamente", "Información", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                // TODO: Implementar UserEditForm
                // var selectedUser = (User)dgvUsers.SelectedRows[0].DataBoundItem;
                // var editForm = new UserEditForm(selectedUser, rrhhInputs);
                // if (editForm.ShowDialog() == DialogResult.OK)
                // {
                //     LoadUsers();
                //     MessageBox.Show("Usuario actualizado exitosamente", "Éxito", 
                //         MessageBoxButtons.OK, MessageBoxIcon.Information);
                // }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al editar usuario: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un usuario para eliminar", "Información", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedUser = (User)dgvUsers.SelectedRows[0].DataBoundItem;

            if (selectedUser.Username == currentUser.Username)
            {
                MessageBox.Show("No puede eliminar su propio usuario", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show(
                $"¿Está seguro que desea eliminar al usuario '{selectedUser.Fullname}' ({selectedUser.Username})?", 
                "Confirmar Eliminación", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Asegurar que el usuario actual esté establecido
                    rrhhInputs.SetCurrentUser(currentUser);
                    rrhhInputs.DeleteUser(selectedUser);
                    LoadUsers();
                    MessageBox.Show("Usuario eliminado exitosamente", "Éxito", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar usuario: {ex.Message}", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
            txtSearch.Clear();
        }

        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEdit_Click(sender, e);
            }
        }
    }
}
