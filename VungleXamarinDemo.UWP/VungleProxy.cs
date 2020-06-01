using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VungleSDK;

namespace VungleXamarinDemo.UWP
{
    class VungleProxy : IVungleInterface
    {
        VungleAd m_vungle;

        public event NotifyInitializedDelegate VungleInitializedEvent;
        public event NotifyAdLoaded VungleAdLoadedEvent;
        public event NotifyDiagnostic VungleDiagnosticEvent;

        public void InitializeVungle(string appID)
        {
            m_vungle = AdFactory.GetInstance(appID);

            m_vungle.OnInitCompleted += M_vungle_OnInitCompleted;
            m_vungle.OnAdPlayableChanged += M_vungle_OnAdPlayableChanged;
            m_vungle.Diagnostic += M_vungle_Diagnostic;
        }

        public void LoadAd(string placementID)
        {
            m_vungle.LoadAd(placementID);
        }


        public async void PlayAd(string placementID)
        {
            await m_vungle.PlayAdAsync(new AdConfig(), placementID);
        }

        private void M_vungle_Diagnostic(object sender, DiagnosticLogEvent e)
        {
            VungleDiagnosticEvent?.Invoke(e.Message);
        }

        private void M_vungle_OnInitCompleted(object sender, ConfigEventArgs e)
        {
            List<String> placements = new List<string>();

            if (e.Placements != null)
            {
                foreach(var placement in e.Placements)
                {
                    placements.Add(placement.ReferenceId);
                }
            }
            VungleInitializedEvent?.Invoke(e.Initialized, placements, e.ErrorMessage);
        }

        private void M_vungle_OnAdPlayableChanged(object sender, AdPlayableEventArgs e)
        {
            VungleAdLoadedEvent?.Invoke(e.Placement, e.AdPlayable);
        }
    }
}
