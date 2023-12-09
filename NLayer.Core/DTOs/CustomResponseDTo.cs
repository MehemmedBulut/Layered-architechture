using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public class CustomResponseDTo<T>
    {
        public T Data { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }


        public static CustomResponseDTo<T> Success(int statusCode, T data)
        {
            return new CustomResponseDTo<T> { Data = data, StatusCode = statusCode};
        }
        public static CustomResponseDTo<T> Success(int statusCode)
        {
            return new CustomResponseDTo<T> {StatusCode = statusCode};
        }
        public static CustomResponseDTo<T> Fail(int statusCode ,List<string> errors)
        {
            return new CustomResponseDTo<T> { StatusCode = statusCode, Errors = errors};
        }
        public static CustomResponseDTo<T> Fail(int statusCode, string error)
        {
            return new CustomResponseDTo<T> { StatusCode = statusCode, Errors = new List<string> { error } };
        }
    }
}
