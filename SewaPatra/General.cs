using Microsoft.AspNetCore.Mvc.Rendering;
using SewaPatra.BusinessLayer;
using SewaPatra.Models;
using System.Collections.Generic;

namespace SewaPatra.DataAccess
{
    public class General
    {
        public readonly AreaService _AreaService;
        public readonly CoordinatorService _CoordinatorService;
        public readonly DonationBoxService _DonationBoxService;
        public readonly DonorService _DonorService;
        public General(AreaService areaService, CoordinatorService coordinatorService, DonationBoxService donationBoxService,
           DonorService donorService)
        {
            _AreaService = areaService;
            _CoordinatorService = coordinatorService;
            _DonationBoxService = donationBoxService;
            _DonorService = donorService;
        }
        public SelectList GetAreas()
        {
            List<Area> areas = _AreaService.GetAllAreas();
            if (areas != null && areas.Count > 0)
            {
                List<SelectListItem> areaList = new List<SelectListItem>();
                foreach (var area in areas)
                {
                    areaList.Add(new SelectListItem
                    {
                        Value = area.Id.ToString(),
                        Text = area.Area_name
                    });
                }
                return new SelectList(areaList, "Value", "Text");
            }
            return new SelectList(Enumerable.Empty<SelectListItem>(), "Value", "Text");
        }
    }
}