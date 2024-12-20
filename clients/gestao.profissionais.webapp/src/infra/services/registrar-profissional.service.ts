import { http } from "../http";
import { ResponseToCreate } from "./response/response-to-create.dto";
import { ResponseAPIDTO } from "./response/response.api.dto";

const registrarProfissionalService = async (
  values: any
): Promise<ResponseAPIDTO<ResponseToCreate<string>>> => {
  const response = await http.post("/api/Profissional", values);
  return new ResponseAPIDTO<ResponseToCreate<string>>(response);
};
export { registrarProfissionalService };
