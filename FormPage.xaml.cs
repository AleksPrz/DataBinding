using SistemaEscolar;
using System.ComponentModel;
using System.Text;
using System.Text.Json;

namespace DataBinding;

public partial class FormPage : ContentPage, INotifyPropertyChanged
{
    private readonly HttpClient _httpClient = new HttpClient();
    private string nombre = "Alejandro";
	public string Nombre
	{
		get => nombre;
		set
		{
			nombre = value;
			OnPropertyChanged();
		}
	}
	private string apellido = "Taboada";
	public string Apellido
	{
		get => apellido;
		set
		{
			apellido = value;
			OnPropertyChanged();
		}
	}
	private string sexo = "h";
	public string Sexo
	{
		get => sexo;
		set
		{
			sexo = value;
			OnPropertyChanged();
		}
	}
	private string id_rol = "1";
	public string Id_rol
	{
		get => id_rol;
		set
		{
			id_rol = value;
			OnPropertyChanged();
		}
	}
	private DateTime fh_nac = DateTime.Now;
	public DateTime Fh_nac
	{
		get => fh_nac;
		set
		{
			fh_nac = value;
			OnPropertyChanged();
		}
	}
	public FormPage()
	{
		InitializeComponent();
		BindingContext = this;
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
        int rol = int.Parse(Id_rol);
        string fecha = Fh_nac.ToString("yyyy-MM-dd");

        if (Nombre == "" || Apellido == "" || Sexo == "" || (rol < 1 || rol > 4)) return;
		
		
		PersonaModel persona = new PersonaModel(Nombre, Apellido, fecha, Sexo, rol);
		
		string json = JsonSerializer.Serialize(persona);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
		var response = await _httpClient.PostAsync("https://fi.jcaguilar.dev/v1/escuela/persona", content);

		if (response.IsSuccessStatusCode)
		{
			Nombre = "";
			Apellido = "";
		}
    }

	private async void Volver_Clicked(object sender, EventArgs e)
	{
        await Navigation.PopAsync();
    }
}