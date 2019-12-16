using MvvmCross.ViewModels;

namespace Gallery.Core.ViewModels
{
    public abstract class BaseViewModel<TParameter> : MvxViewModel<TParameter>
        where TParameter : class
    {
        protected BaseViewModel()
        {
        }
    }
}
