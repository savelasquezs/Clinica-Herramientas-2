using Clinica_Herramientas_2.Infrastructure.Config;

namespace Clinica_Herramientas_2
{
    public partial class Form1 : Form
    {
        private readonly Config config;
        
        public Form1(Config config)
        {
            this.config = config;
            InitializeComponent();
        }
    }
}
