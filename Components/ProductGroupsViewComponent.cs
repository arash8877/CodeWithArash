using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CodeWithArash.Data;
using CodeWithArash.Data.Repositories;
using CodeWithArash.Models;

namespace CodeWithArash.Components
{
  public class ProductGroupsViewComponent : ViewComponent
  {
    private IGroupRepository _groupRepository;

    public ProductGroupsViewComponent(IGroupRepository groupRepository)
    {
      _groupRepository = groupRepository;
    }


    public async Task<IViewComponentResult> InvokeAsync()
    {

      return View(_groupRepository.GetGroupForShow());
    }
  }
}
