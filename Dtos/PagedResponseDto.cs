﻿namespace LibraryManagement.Dtos
{
    public class PagedResponseDto<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public List<T> Data { get; set; }

        public PagedResponseDto()
        {
            Data = new List<T>();
        }
    }
}
