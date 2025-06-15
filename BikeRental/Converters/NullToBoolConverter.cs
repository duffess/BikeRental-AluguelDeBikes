// importa o namespace system, que contem classes basicas como object e exception
using System;

// importa funcionalidades para manipulacao de cultura e formatacao de dados
using System.Globalization;

// importa o namespace de data binding do wpf, usado para criar conversores personalizados
using System.Windows.Data;

namespace BikeRental.Converters
{
    // define uma classe chamada nulltoboolconverter que implementa a interface ivalueconverter
    // essa interface permite criar conversores de valor personalizados para o binding no xaml
    public class NullToBoolConverter : IValueConverter
    {
        // metodo chamado quando o binding precisa converter um valor da origem para o destino (ex: model -> view)
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // retorna true se o valor nao for nulo e false se for nulo
            // isso e util para, por exemplo, habilitar ou desabilitar um botao baseado na presenca de um objeto
            return value != null;
        }

        // metodo chamado quando o binding precisa converter o valor de volta do destino para a origem (ex: view -> model)
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // neste caso a conversao de volta nao e implementada
            // entao lancamos uma excecao para indicar que isso nao deve ser usado
            throw new NotImplementedException();
        }
    }
}
