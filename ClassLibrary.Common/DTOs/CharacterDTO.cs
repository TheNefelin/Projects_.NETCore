﻿namespace ClassLibrary.Common.DTOs
{
    public class CharacterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImgUrl { get; set; } = string.Empty;
        public int Id_Game { get; set; }
    }
}
