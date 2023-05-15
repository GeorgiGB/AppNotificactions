using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using AppNotificactions.Data;
using FirebaseAdmin.Messaging;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using System.Text;
using Syncfusion.Blazor.Notifications;
using Microsoft.EntityFrameworkCore.Internal;
using System.Diagnostics;

namespace AppNotificactions.Components
{
    public partial class Formulario
    {
        //Notificacion emergente
        private SfToast toastRef;

        private DatosDataContext? _context;


        [Inject] public HttpClient http { get; set; }
        /*
         * Tema seleccionado y lista de temas
         */

        private List<Topic> listaTopics = new();

        /*
         * Nuevo objeto datos y una lista de datos que se mostraran por pantalla
         */
        private Datos NuevosDatos = new();

        private List<Datos> DatosMostrados = new();

        protected override async Task OnInitializedAsync()
        {
            //_editContext = new EditContext(NuevosDatos);

            await ShowTopics();

            await ShowDatos();
        }
        /*
         * Funcion que tiene que mandar una notificacion a cualquier dispositivo que este suscrito con el topic
         */
        private async Task CrearMensaje()
        {
            string key = "key=AAAAHbLlUmY:APA91bEfvgQ-ospHroGQbFmYzCWMO1PJ4JFXhrLfSahUH48DQhWgAa2SQL2ViboFOUsPGqaIoczMzxNp1-Q9UOCtGxVW9r6aE62pJSXlvZXJscYCCmINhUvLb8UXQPHploR7fnxC4SIw";
            var request = new HttpRequestMessage(HttpMethod.Post, "https://fcm.googleapis.com/fcm/send");
            http.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", key);

            request.Content = new StringContent($@"{{
                            ""data"": {{
                                ""WX_PUSH_EXT_VERSION"":""1.0"",
                                ""WX_PROP_TITRE"":""{NuevosDatos.Titulo}"",
                                ""WX_PROP_MESSAGE"":""{NuevosDatos.Msg}"",
                                ""WX_PROP_PRIORITE"":4,
                                ""WX_PROP_ACTIVEAPPLICATION"":true,
                                ""title"" : ""{NuevosDatos.Titulo}"",
                                ""body"" : ""{NuevosDatos.Msg}"",
                                ""priority"" : ""high""
                            }},
                            ""to"": ""/topics/{NuevosDatos.TopicId}""
                            }}", Encoding.UTF8, "application/json");
            var response = await http.SendAsync(request);
            response.EnsureSuccessStatusCode();
            await response.Content.ReadAsStringAsync();
            GuardarNotificacionBB();
            //await NotificacionFlotante("Informacion enviada correctamente", "Los datos se han registrado en la base de datos");
            
        }

        
        /*
         * Funcion asincrona que guardara los datos creados a la base de datos
         */
        private async 
        
        /*
         * Funcion asincrona que guardara los datos creados a la base de datos
         */
        Task
        GuardarNotificacionBB()
        {
            //funcion que guarda el mensaje que tiene que enviar a la base de datos
            //_context ??= await DatosDataContextFatory.CreateDbContextAsync();

            NuevosDatos.FechaEnvio = DateTime.Now;
            _context?.Datos.Add(NuevosDatos);
            _context?.SaveChanges();

            await ShowDatos();
            //await NotificacionFlotante("Informacion enviada correctamente", "Los datos se han registrado en la base de datos");
        }

        /*
         * Notificacion flotante que constara de un titulo y un cuerpo
         
        private async Task NotificacionFlotante(string titulo, string cuerpo)
        {
            await this.toastRef.ShowAsync();
        }*/
        /*
         * Muestra los temas a los que se le puede enviar el mensaje
         */
        public async Task ShowTopics()
        {
            _context ??= await DatosDataContextFatory.CreateDbContextAsync();

            if (_context is not null)
            {
                listaTopics = await _context.Topics.ToListAsync();
            }

            //if (_context is not null) await _context.DisposeAsync();
        }
        /*
         * Muestra en la tabla los datos de las notificaciones registradas en la base de datos
         */
        public async Task ShowDatos()
        {
            _context ??= await DatosDataContextFatory.CreateDbContextAsync();

            if (_context is not null)
            {
                DatosMostrados = await _context.Datos.ToListAsync();
            }

            //if (true) await _context.DisposeAsync();
        }

        /*
         * Si el formulario no se rellena correctamente se mandara una notificacion
         */
        private void OnInvalidSubmit()
        {
            //NotificacionFlotante("No se ha podido subir", "Falta contenido o algo salio mal");
        }
        /*
         * Funcion que se invoca en el Editform cuando se vaya a mandar la informacion tanto en la base de datos como a los dispositivos moviles
         */
        private async Task EnviarDatos()
        {
            await CrearMensaje();
        }

    }
}

