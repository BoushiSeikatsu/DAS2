using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DS2Implementace
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ServerSide_Click(object sender, RoutedEventArgs e)
        {
            DatabaseService service = new DatabaseService();
            List<SqlParameter> parameters = new List<SqlParameter>();
            int projectId;
            if (Int32.TryParse(ProjectId.Text, out projectId))
            {
                parameters.Add(new SqlParameter("@p_projekt_id", SqlDbType.Int) { Value = projectId });
                parameters.Add(new SqlParameter("@p_success", SqlDbType.Int) { Value = 0 });
                service.RunServerSide("P_ARCHIVE_PROJECT", parameters);
            }   
        }

        private void ApplicationSide_Click(object sender, RoutedEventArgs e)
        {
            DatabaseService service = new DatabaseService();
            int projectId;
            if (Int32.TryParse(ProjectId.Text, out projectId))
            {
                service.RunClientSide(projectId);
            }
        }
    }
}