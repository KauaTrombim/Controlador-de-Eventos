using Eventos.Models;
namespace Eventos.Views;

public partial class home : ContentPage
{
	App Propriedades;
	public home()
	{
		InitializeComponent();
		Propriedades = (App)Application.Current;

		dtpck_inicio.MinimumDate = DateTime.Now;
		dtpck_termino.MinimumDate = dtpck_inicio.Date.AddDays(1);
	}
    private void dtpck_inicio_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = sender as DatePicker;

        DateTime data_selecionada = elemento.Date;

        dtpck_termino.MinimumDate = data_selecionada.AddDays(1);
    }

    private async void Advance_Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Evento evento = new Evento()
            {
                Nome = Convert.ToString(txt_nome.Text),
                Local = Convert.ToString(txt_local.Text),
                Dt_inicio = dtpck_inicio.Date,
                Dt_termino = dtpck_termino.Date,
                Participantes = Convert.ToInt32(stp_participantes.Value),
                CustoIngresso = Convert.ToDouble(txt_custo.Text),
            };

            await Navigation.PushAsync(new resumo()
            {
                BindingContext = evento
            });
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "Ok");
        }
    }
}