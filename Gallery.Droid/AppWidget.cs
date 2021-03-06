﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Appwidget;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Gallery.Droid
{
    [BroadcastReceiver(Label = "HellApp Widget")]
    [IntentFilter(new string[] { "android.appwidget.action.APPWIDGET_UPDATE"})]
    [MetaData("android.appwidget.provider", Resource = "@xml/appwidget_provider")]
    public class AppWidget : AppWidgetProvider { 

        public override void OnUpdate(Context context, AppWidgetManager appWidgetManager, int[] appWidgetIds) {
            var me = new ComponentName(context, Java.Lang.Class.FromType(typeof(AppWidget)).Name);
            appWidgetManager.UpdateAppWidget(me, BuildRemoteViews(context, appWidgetIds));
        }

        private RemoteViews BuildRemoteViews(Context context, int[] appWidgetIds) {
            var widgetView = new RemoteViews(context.PackageName, Resource.Layout.widget);
            SetTextViewText(widgetView);
            RegisterClicks(context, appWidgetIds, widgetView);
            return widgetView;
        }

        private void SetTextViewText(RemoteViews widgetView) { 
            widgetView.SetTextViewText(Resource.Id.widget_medium, "HelloAppWidget");
            widgetView.SetTextViewText(Resource.Id.widget_small, 
                string.Format("Last update: {0:H:mm:ss}", DateTime.Now));
        }

        private void RegisterClicks(Context context, int[] appWidgetIds, RemoteViews widgetView) {
            var intent = new Intent(context, typeof(AppWidget));
            intent.SetAction(AppWidgetManager.ActionAppwidgetUpdate);
            intent.PutExtra(AppWidgetManager.ExtraAppwidgetIds, appWidgetIds);
            var piBackground = PendingIntent.GetBroadcast
                (context, 0, intent, PendingIntentFlags.UpdateCurrent);
            widgetView.SetOnClickPendingIntent(Resource.Id.widget_background, piBackground);
        }

        private static string AnnouncementClick = "AnnouncementClickTag\"\"";

        public override void OnReceive(Context context, Intent intent) { }
    }
}