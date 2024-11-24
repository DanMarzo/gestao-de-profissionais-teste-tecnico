import axios, { AxiosError } from "axios";

const baseURL = import.meta.env.VITE_URL_API;

const http = axios.create({ baseURL });
http.interceptors.response.use(
  function (response) {
    // Any status code that lie within the range of 2xx cause this function to trigger
    // Do something with response data
    return Promise.resolve(response);
  },
  function (error) {
    if (error instanceof AxiosError) {
        //Em caso de erro do tipo axios, faca a tratativa para nao cair no catch
      return Promise.resolve(error);
    }
    return Promise.reject(error);
  }
);

export { http };