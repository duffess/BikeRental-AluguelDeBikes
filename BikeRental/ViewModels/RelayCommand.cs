using System;
using System.Windows.Input;

namespace BikeRental
{
    // comando reutilizável que recebe ações para executar e condições para habilitar
    public class RelayCommand : ICommand
    {
        // ação executada quando o comando é chamado
        private readonly Action<object> execute;

        // condição que diz se o comando pode ser executado (opcional)
        private readonly Predicate<object> canExecute;

        // construtor recebe a ação e opcionalmente a condição
        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }

        // verifica se o comando pode ser executado agora
        public bool CanExecute(object parameter) => canExecute == null || canExecute(parameter);

        // executa a ação do comando
        public void Execute(object parameter) => execute(parameter);

        // evento disparado quando a condição CanExecute pode ter mudado (para habilitar/desabilitar botões)
        public event EventHandler CanExecuteChanged;

        // método para disparar o evento CanExecuteChanged
        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
