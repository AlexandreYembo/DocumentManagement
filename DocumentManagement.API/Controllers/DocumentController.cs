using AutoMapper;
using DocumentManagement.API.Handlers;
using DocumentManagement.Application.DTOs;
using DocumentManagement.Application.Interfaces;
using DocumentManagement.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace DocumentManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "document-management-v1")]
    [ServiceFilter(typeof(UsernameRequirementFilter))]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        /// <summary>
        /// Get Uploaded Documents
        /// </summary>
        [SwaggerResponse((int)HttpStatusCode.OK, "Documents returned succefully.", typeof(IEnumerable<DocumentDTO>))]
        [Route("")]
        [HttpGet]
        public IActionResult List()
        {
            return Ok(_documentService.List());
        }

        /// <summary>
        /// Get Uploaded Documents
        /// </summary>
        [SwaggerResponse((int)HttpStatusCode.Created, "Documents created succefully.", typeof(long))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Error.", typeof(IEnumerable<string>))]
        [Route("")]
        [HttpPost]
        public IActionResult Post([FromBody] DocumentInsertDTO value)
        {
            var validation = ModelState.Values.SelectMany(x => x.Errors).Select(c => c.ErrorMessage);
            if (validation.Any())
                return BadRequest(validation);

            var username = this.HttpContext.Request.Headers.Keys.FirstOrDefault(k => k.Equals("username", StringComparison.InvariantCultureIgnoreCase));

           return StatusCode((int)HttpStatusCode.Created, _documentService.Create(Mapper.Map<Document>(value), username));
        }

        /// <summary>
        /// Update Access Date
        /// </summary>
        [SwaggerResponse((int)HttpStatusCode.NoContent, "Documents changed succefully.")]
        [HttpPatch("{id}")]
        public IActionResult UpdateAccessDate(long id)
        {
            if (id <= 0)
                return BadRequest();

            _documentService.UpdateAccessDate(id);

            return NoContent();
        }

        /// <summary>
        /// Delete document
        /// </summary>
        [SwaggerResponse((int)HttpStatusCode.NoContent, "Documents deleteds succefully.")]
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            if (id <= 0)
                return BadRequest();

            _documentService.Delete(id);

            return NoContent();
        }
    }
}
