using System;
using Android.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace Gallery.Droid.Views.Adapter
{

    public class MyMvxViewHolder<TItemViewModel> : MvxRecyclerViewHolder
    {
        public MyMvxViewHolder(View itemView, IMvxAndroidBindingContext context,
            Action<View, MvxFluentBindingDescriptionSet<MyMvxViewHolder<TItemViewModel>, TItemViewModel>>
                bindingAction)
            : base(itemView, context)
        {
            this.DelayBind(() =>
            {
                if (bindingAction == null)
                    return;

                var set = this.CreateBindingSet<MyMvxViewHolder<TItemViewModel>, TItemViewModel>();
                bindingAction(itemView, set);
                set.Apply();
            });
        }
    }
}