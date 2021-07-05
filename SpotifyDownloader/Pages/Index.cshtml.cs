using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AppLogger.Controls;
using AppLogger.Model;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Properties;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PdfGenerationHelper.Model;
using PdfGenerationHelper.Controls;
using SpotifyDownloader.Model;
using Microsoft.AspNetCore.Http;
using iText.Kernel.Events;
using iText.Layout.Element;
using PdfGenerationHelper.IEventHandlers;
using HttpRequestHelper.Control;
using Newtonsoft.Json;
using System.Net;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Infrastructure;

namespace SpotifyDownloader.Pages
{
    public class CreateMusicModel : PageModel
    {
        private readonly SpotifyDownloader.Model.SpotifyDownloaderDbContext _context;

        public CreateMusicModel(SpotifyDownloader.Model.SpotifyDownloaderDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Music Music { get; set; }

        [BindProperty]
        public IFormFile Imagem { get; set; }
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Musics.Add(Music);
            await _context.SaveChangesAsync("Gabriel");

            return RedirectToPage("./Index");
        }

        public IActionResult OnPostImprimir()
        {
            using MemoryStream memStream = new();
            using PdfWriter wri = new(memStream);
            PdfDocument pdf = new(wri);
            pdf.AddEventHandler(PdfDocumentEvent.START_PAGE, new HeaderEventHandler("Pro Felipe ver", Color.BLACK, 16));
            pdf.AddEventHandler(PdfDocumentEvent.START_PAGE, new PaginationEventHandler(Color.BLACK, 10));

            Document document = new(pdf);
            document.Add(FilesControl.CreateText("Titulo", 16, TextAlignment.CENTER, Color.BLACK));
            document.Add(FilesControl.CreateText("Belo Horizonte", 14, TextAlignment.RIGHT, Color.BLACK));
            document.Add(FilesControl.CreateTable(12, _context.Musics, TextAlignment.CENTER, 100, HorizontalAlignment.CENTER, Color.WHITE));
            document.Add(FilesControl.CreateTable(12, _context.Musics, TextAlignment.CENTER, 100, HorizontalAlignment.CENTER, Color.WHITE));
            document.Add(FilesControl.CreateTable(12, _context.Musics, TextAlignment.CENTER, 100, HorizontalAlignment.CENTER, Color.WHITE));
            document.Add(FilesControl.CreateTable(12, _context.Musics, TextAlignment.CENTER, 100, HorizontalAlignment.CENTER, Color.WHITE));
            document.Add(FilesControl.CreateTable(12, _context.Musics, TextAlignment.CENTER, 100, HorizontalAlignment.CENTER, Color.WHITE));
            document.Add(FilesControl.CreateTable(12, _context.Musics, TextAlignment.CENTER, 100, HorizontalAlignment.CENTER, Color.WHITE));
            document.Add(FilesControl.CreateTable(12, _context.Musics, TextAlignment.CENTER, 100, HorizontalAlignment.CENTER, Color.WHITE));
            document.Add(FilesControl.CreateTable(12, _context.Musics, TextAlignment.CENTER, 100, HorizontalAlignment.CENTER, Color.WHITE));
            document.Add(FilesControl.CreateTable(12, _context.Musics, TextAlignment.CENTER, 100, HorizontalAlignment.CENTER, Color.WHITE));
            document.Add(FilesControl.CreateTable(12, _context.Musics, TextAlignment.CENTER, 100, HorizontalAlignment.CENTER, Color.WHITE));
            document.Add(FilesControl.CreateTable(12, _context.Musics, TextAlignment.CENTER, 100, HorizontalAlignment.CENTER, Color.WHITE));
            document.Add(FilesControl.CreateTable(12, _context.Musics, TextAlignment.CENTER, 100, HorizontalAlignment.CENTER, Color.WHITE));
            document.Add(FilesControl.CreateTable(12, _context.Musics, TextAlignment.CENTER, 100, HorizontalAlignment.CENTER, Color.WHITE));
            document.Add(FilesControl.CreateTable(12, _context.Musics, TextAlignment.CENTER, 100, HorizontalAlignment.CENTER, Color.WHITE));
            document.Add(FilesControl.CreateTable(12, _context.Musics, TextAlignment.CENTER, 100, HorizontalAlignment.CENTER, Color.WHITE));
            document.Add(FilesControl.CreateTable(12, _context.Musics, TextAlignment.CENTER, 100, HorizontalAlignment.CENTER, Color.WHITE));
            document.Add(FilesControl.CreateTable(12, _context.Musics, TextAlignment.CENTER, 100, HorizontalAlignment.CENTER, Color.WHITE));
            document.Add(FilesControl.CreateTable(12, _context.Musics, TextAlignment.CENTER, 100, HorizontalAlignment.CENTER, Color.WHITE));
            document.Add(FilesControl.CreateTable(12, _context.Musics, TextAlignment.CENTER, 100, HorizontalAlignment.CENTER, Color.WHITE));
            document.Add(FilesControl.CreateTable(12, _context.Musics, TextAlignment.CENTER, 100, HorizontalAlignment.CENTER, Color.WHITE));

            document.Close();

            return new FileStreamResult(new MemoryStream(memStream.ToArray()), "application/pdf");
        }
    }
}
