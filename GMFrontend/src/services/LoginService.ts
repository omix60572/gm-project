import CookieStorageService from "./CookieStorageService";

class LoginService {
  private static Instance: LoginService | null = null;
  private readonly cookieStorageService: CookieStorageService;

  private constructor() {
    this.cookieStorageService = CookieStorageService.getInstance();
  }
  public static getInstance(): LoginService {
    LoginService.Instance ??= new LoginService();
    return LoginService.Instance;
  }

  // loginAction() performLogin
}
