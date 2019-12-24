using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;

namespace Gallery.Droid.Views.Adapter
{
    public class MyMvxRecyclerAdapte : MvxRecyclerAdapter
    {
        private readonly Func<View, IMvxAndroidBindingContext, RecyclerView.ViewHolder> _viewHolderFactory;

        public MyMvxRecyclerAdapte(IMvxAndroidBindingContext bindingContext,
            Func<View, IMvxAndroidBindingContext, RecyclerView.ViewHolder> viewHolderFactory)
            : base(bindingContext)
        {
            if (viewHolderFactory == null)
                throw new ArgumentNullException(nameof(viewHolderFactory));

            _viewHolderFactory = viewHolderFactory;
        }
       

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemBindingContext = new MvxAndroidBindingContext(parent.Context, BindingContext.LayoutInflaterHolder);
            var view = InflateViewForHolder(parent, viewType, itemBindingContext);

            return _viewHolderFactory(view, itemBindingContext);
        }
        
    }
}