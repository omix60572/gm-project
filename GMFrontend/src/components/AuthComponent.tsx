import { useEffect, useState, type ReactNode } from "react";
import axios from "axios";
import { ApiBaseUrl, GetTokenApi } from "../common/Endpoints";
import { AppNameHeader } from "../common/Headers";
import { FrontendAppName, StringEmpty } from "../common/CommonConst";
import CookieStorageService from "../services/CookieStorageService";
import { CookieStorageAppTokenKey } from "../common/CookieStorageKeys";
import StringUtils from "../common/StringUtils";
import Utils from "../common/Utils";

interface AuthComponentProps {
  children: ReactNode;
}

function AuthComponent({ children }: Readonly<AuthComponentProps>) {
  const [loading, setLoading] = useState(true);
  const cookieStorageService = CookieStorageService.getInstance();

  const api = axios.create({
    baseURL: ApiBaseUrl,
  });
  api.interceptors.request.use((config) => {
    config.headers.set(AppNameHeader, FrontendAppName, true);
    return config;
  });

  const saveApiTokenToCookie = (appToken: string, expireHours: number) => {
    cookieStorageService
      .saveValue(CookieStorageAppTokenKey, appToken, expireHours)
      .catch((error) => console.log(error))
      .finally(() => setLoading(false));
  };

  const getApiToken = () => {
    let appToken = StringEmpty;
    let expireHours = 0;

    api
      .get(`${GetTokenApi}/${FrontendAppName}`)
      .then((tokenResponse) => {
        if (!Utils.isNullOrUndefined(tokenResponse.data)) {
          appToken = tokenResponse.data.applicationToken;
          expireHours = tokenResponse.data.expireHours;
        }
      })
      .catch((error) => console.log(error))
      .finally(() => saveApiTokenToCookie(appToken, expireHours));
  };

  useEffect(() => {
    const authorization = () => {
      cookieStorageService
        .getValue(CookieStorageAppTokenKey)
        .then((cookie) => {
          if (!StringUtils.isEmpty(cookie)) {
            setLoading(false);
            return;
          }

          getApiToken();
        });
    };

    authorization();
  }, []);

  return (
    <>{loading ? <div className="application-loading-div"></div> : children}</>
  );
}

export default AuthComponent;
