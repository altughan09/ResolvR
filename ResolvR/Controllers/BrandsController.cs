using MediatR;
using Microsoft.AspNetCore.Mvc;
using ResolvR.Application.Brands.Commands.CreateBrand;
using ResolvR.Application.Brands.Commands.DeleteBrand;
using ResolvR.Application.Brands.Commands.UpdateBrand;
using ResolvR.Application.Brands.Dtos;
using ResolvR.Application.Brands.Queries.GetAllBrands;
using ResolvR.Application.Brands.Queries.GetBrandById;
using ResolvR.Domain.Shared;

namespace ResolvR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class BrandsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retrieves all brands.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A list of all brands.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BrandDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var brands = await _mediator.Send(new GetAllBrandsQuery(), cancellationToken);
            return Ok(brands);
        }

        /// <summary>
        /// Retrieves a brand by its identifier.
        /// </summary>
        /// <param name="id">The brand identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The brand if found, otherwise a not found response.</returns>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(BrandDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error),StatusCodes.Status404NotFound)]     
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            var brand = await _mediator.Send(new GetBrandByIdQuery(id), cancellationToken);

            return brand.IsSuccess
                ? Ok(brand.Value)
                : NotFound(brand.Error);
        }

        /// <summary>
        /// Creates a new brand based on the specified request.
        /// </summary>
        /// <param name="command">The create brand command request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The identifier of the newly created brand.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Error),StatusCodes.Status400BadRequest)]     
        public async Task<IActionResult> Post([FromBody] CreateBrandCommand command,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);

            return result.IsSuccess
                ? CreatedAtAction(nameof(Get), new { id = result.Value }, result.Value)
                : BadRequest(result.Error);
        }

        /// <summary>
        /// Updates an existing brand based on the specified request.
        /// </summary>
        /// <param name="id">The brand identifier.</param>
        /// <param name="command">The update brand command request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>No content if successful, otherwise a bad request response.</returns>
        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Error),StatusCodes.Status400BadRequest)]        
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateBrandCommand command,
            CancellationToken cancellationToken)
        {
            command.Id = id;
            var result = await _mediator.Send(command, cancellationToken);

            return result.IsSuccess
                ? NoContent()
                : BadRequest(result.Error);
        }

        /// <summary>
        /// Deletes a brand by its identifier.
        /// </summary>
        /// <param name="id">The brand identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>No content if successful, otherwise a bad request response.</returns>
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Error),StatusCodes.Status400BadRequest)]        
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeleteBrandCommand(id), cancellationToken);

            return result.IsSuccess
                ? NoContent()
                : BadRequest(result.Error);
        }
    }
}