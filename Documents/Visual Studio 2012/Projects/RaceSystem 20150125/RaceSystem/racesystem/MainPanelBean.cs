using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceSystem
{
    class MainPanelBean
    {
        private PnlHome pnlHome = null;
        private PnlMngEvents pnlMngEvents = null;
        private PnlAddDriverToEvent pnlAddDriverToEvent = null;
        private PnlReports pnlReports = null;
        private PnlManageRfidNo pnlManageRfidNo = null;
        
        //Al
        private PnlDriver pnlDriver = null;

        public PnlHome getPnlHome()
        {
            if (pnlHome == null)
                pnlHome = new PnlHome();

            return pnlHome;
        }

        public PnlMngEvents getPnlMngEvents()
        {
            if (pnlMngEvents == null)
                pnlMngEvents = new PnlMngEvents();

            return pnlMngEvents;
        }

        public PnlAddDriverToEvent  getPnlAddDriverToEvent()
        {
             if (pnlAddDriverToEvent == null)
                pnlAddDriverToEvent = new PnlAddDriverToEvent();

            return pnlAddDriverToEvent;
        }

        //Al

        public PnlDriver getPnlDriver()
        {
            if (pnlDriver == null)
                pnlDriver = new PnlDriver();

            return pnlDriver;
        }

        // Kenneth
        public PnlReports getPnlReport()
        {
            if (pnlReports == null)
                pnlReports = new PnlReports();

            return pnlReports;
        }

        // Kenneth
        public PnlManageRfidNo getPnlManageRfidNo()
        {
            if (pnlManageRfidNo == null)
                pnlManageRfidNo = new PnlManageRfidNo();

            return pnlManageRfidNo;
        }

    }
}
