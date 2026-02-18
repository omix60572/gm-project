import { IsExtendedLogging } from "../common/CommonConst";

class LoggingFacade {
  private static Instance: LoggingFacade | null = null;

  private constructor() { }
  public static getInstance(): LoggingFacade {
    LoggingFacade.Instance ??= new LoggingFacade();
    return LoggingFacade.Instance;
  }

  public trace(message: string) {
    if (IsExtendedLogging)
      console.log(message);
  }

  public info(message: string) {
    if (IsExtendedLogging)
      console.info(message);
  }

  public warn(message: string) {
    console.warn(message);
  }

  public error(message?: string, error?: any) {
    console.error(message, error);
  }
}

export default LoggingFacade;
