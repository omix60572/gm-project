import axios, { type AxiosInstance } from "axios";
import { ApiBaseUrl } from "../common/Endpoints";
import { FrontendAppName } from "../common/CommonConsts";
import { AppNameHeader, AppTokenHeader } from "../common/Headers";
import CookieStorageService from "../services/CookieStorageService";
import { CookieStorageAppTokenKey } from "../common/CookieStorageKeys";

class ApiFacade {
  private static Instance: ApiFacade | null = null;

  private readonly api: AxiosInstance;
  private readonly cookieStorageService: CookieStorageService;

  private constructor() {
    this.cookieStorageService = CookieStorageService.getInstance();
    this.api = axios.create({
      baseURL: ApiBaseUrl
    });

    this.api.interceptors.request.use(async (config) => {
      config.headers.set(AppNameHeader, FrontendAppName, true);
      config.headers.set(AppTokenHeader, await this.cookieStorageService.getValue(CookieStorageAppTokenKey), true);
      return config;
    });
  }
  public static getInstance(): ApiFacade {
    ApiFacade.Instance ??= new ApiFacade();
    return ApiFacade.Instance;
  }

  public async get<T = any>(url: string, params?: any): Promise<T> {
    const response = await this.api.get<{data: T}>(url, { params });
    return response.data as T;
  }

  public async post<T = any>(url: string, data?: any): Promise<T> {
    const response = await this.api.post<{data: T}>(url, data);
    return response.data as T;
  }
}

export default ApiFacade;
