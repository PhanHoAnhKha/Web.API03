﻿using Microsoft.AspNetCore.Mvc;
using WebApi03.Data;
using WebApi03.DTO;
using WebApi03.Models;
using WebApi03.Repositories;

[Route("api/[controller]")]
        [ApiController]
        public class AuthorsControllers : ControllerBase
        {
            private readonly AppDbContext _dbContext;
            private readonly IAuthorRepository _authorRepository;

            public AuthorsControllers(AppDbContext dbContext, IAuthorRepository authorRepository)
            {
                _dbContext = dbContext;
                _authorRepository = authorRepository;
            }
            [HttpGet("get-all-author")]
            public IActionResult GetAllAuthor()
            {
                var allAuthors = _authorRepository.GellAllAuthors();
                return Ok(allAuthors);
            }
            [HttpGet("get-author-by-id/{id}")]
            public IActionResult GetAuthorById(int id)
            {
                var authorWithId = _authorRepository.GetAuthorById(id);
                return Ok(authorWithId);
            }
            [HttpPost("add - author")]
            public IActionResult AddAuthors([FromBody] AddAuthorRequestDTO
           addAuthorRequestDTO)
            {
                var authorAdd = _authorRepository.AddAuthor(addAuthorRequestDTO);
                return Ok();
            }
            [HttpPut("update-author-by-id/{id}")]
            public IActionResult UpdateBookById(int id, [FromBody] AuthorNoIdDTO
           authorDTO)
            {
                var authorUpdate = _authorRepository.UpdateAuthorById(id, authorDTO);
                return Ok(authorUpdate);
            }
            [HttpDelete("delete-author-by-id/{id}")]
            public IActionResult DeleteBookById(int id)
            {
                var authorDelete = _authorRepository.DeleteAuthorById(id);
                return Ok();
            }
        }
