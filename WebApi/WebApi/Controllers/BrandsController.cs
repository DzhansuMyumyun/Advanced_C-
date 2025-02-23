﻿using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {

        private readonly IBrandService _brandService;
        //builder.Services.AddSingleton<IBrandService, BrandManager>(); => add to Program.cs
        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost]
        public IActionResult Add (CreateBrandRequest createBrandRequest)
        {
            CreatedBrandResponse createsBrandResponse = _brandService.Add(createBrandRequest);

            return Ok(createsBrandResponse);
        }

        [HttpGet]
        public IActionResult Get() 
        {
            return Ok(_brandService.GetAll());
        }
    }
}
