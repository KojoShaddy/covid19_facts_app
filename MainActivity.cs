using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Collections.Generic;
using System;

namespace CovidFactsApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        List<string> facts = new List<string>() {
            "Coronavirus (COVID-19) is an illness caused by a virus that can spread from personto person.",
            "The virus that causes COVID-19 is a new coronavirus that has spread throughout the world. ",
            "COVID-19 symptoms can range from mild (or no symptoms) to severe illness",
            "Stay home if you are sick,except to get medical care.",
            "Avoid public transportation,ride-sharing, or taxis",
            "If you need medical attention,call ahead"
        };
        
        private Button btn_fact;
        private TextView txt_fact;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // reference variable to view elements 
            btn_fact = FindViewById<Button>(Resource.Id.btn_fact);
            txt_fact = FindViewById<TextView>(Resource.Id.text_fact);
            
            btn_fact.Click += OnFactButtonClicked;
            btn_fact.Click += OnNewFactButtonClicked;
        }

        private void OnNewFactButtonClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnFactButtonClicked(object sender, System.EventArgs e)
        {
            txt_fact.Text = GetRandomFact();
        }


        string GetRandomFact()
        {
            //select random fact from list
            Random random = new Random();
            var iRandom= random.Next(facts.Count);
            var mySelectedRandomFact = facts[iRandom];       
            //return selected fact
            return mySelectedRandomFact;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}