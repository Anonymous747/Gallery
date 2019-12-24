using System;
using Android.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using Gallery.Droid.Views.Adapter;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace Gallery.Droid.Views.Extensions
{
    public static class MvxCachedImageViewExtensions
    {
        public static MvxRecyclerView BindItems<TItemViewModel>(this MvxRecyclerView source, IMvxBindingContext bindingContext,
            Action<View, MvxFluentBindingDescriptionSet<MyMvxViewHolder<TItemViewModel>, TItemViewModel>>
                itemBindingAction)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            source.Adapter = new MyMvxRecyclerAdapte((IMvxAndroidBindingContext)bindingContext,
                (view, context) => new MyMvxViewHolder<TItemViewModel>(view, context, itemBindingAction));

            return source;
        }
    }
}