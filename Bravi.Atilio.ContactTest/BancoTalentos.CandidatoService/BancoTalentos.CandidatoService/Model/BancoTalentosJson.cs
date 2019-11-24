using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoTalentos.CandidatoService.Model
{
    public class BancoTalentosJson<T>
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public string Message_key { get; set; }
        public T Data { get; set; }

        public BancoTalentosJson(HttpStatus httpStatus)
        {
            if (httpStatus == HttpStatus.Ok)
            {
                Code = 200;
                Message = "OK";
                Message_key = "OK";
            }
            else if (httpStatus == HttpStatus.BadRequest)
            {
                Code = 400;
                Message = "Bad Request - Check your HTTP parameters";
                Message_key = "Bad Request";
            }
            else if (httpStatus == HttpStatus.InternalServerError)
            {
                Code = 200;
                Message = "OK";
                Message_key = "OK";
            }
        }

        public BancoTalentosJson()
        {

        }

        public BancoTalentosJson<T> GetOK(T data)
        {
            Code = 200;
            Data = data;
            Message = "OK";
            Message_key = "OK";
            return this;
        }

        public BancoTalentosJson<T> GetOKDelete()
        {
            Code = 200;
            Message = "Register was deleted";
            Message_key = "OK";
            return this;
        }

        public BancoTalentosJson<T> GetInternalServerErrorException(Exception ex, bool includeInnerException)
        {
            Code = 500;

            if (includeInnerException && ex.InnerException != null)
            {

                Message = $"{ex.Message} - {ex.InnerException.ToString()}";

            }
            else
            {
                Message = ex.Message;
            }

            Message_key = "Internal Server Error";
            return this;
        }

        public BancoTalentosJson<T> GetInternalServerError(Exception ex)
        {
            Code = 500;
            Message = "Internal Server Error - Try again in a few minutes or contact system administrator";
            Message_key = $"Internal Server Error - {ex.Message} at {ex.StackTrace}";
            return this;
        }

        public BancoTalentosJson<T> GetNotFound()
        {
            Code = 404;
            Message = "Not Found, The provided id was not found, please check your URL";
            Message_key = "Not Found";
            return this;
        }

        public BancoTalentosJson<T> GetBadRequestNull()
        {
            Code = 400;
            Message = "The provided object is null";
            Message_key = "Bad Request";
            return this;
        }

        public BancoTalentosJson<T> GetBadRequest(T errors)
        {
            Code = 400;
            Message = "bad Request";
            Message_key = "Bad Request";
            Data = errors;
            return this;
        }

        public BancoTalentosJson<T> GetConflict(T errors)
        {
            Code = 409;
            Message = "Conflict";
            Message_key = "Conflict";
            Data = errors;
            return this;
        }
    }

    public enum HttpStatus
    {
        Ok,
        BadRequest,
        InternalServerError
    }
}
