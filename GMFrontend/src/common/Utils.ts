class Utils {
  public static isNullOrUndefined(object: any): boolean {
    return object === null || object === undefined;
  }

  public static tryInvoke<T>(method?: (data: T) => {} | undefined, data?: T): string | null {
    let resultMessage: string | null = null;
    
    try {
      if (method !== null && method !== undefined && data !== null && data !== undefined) {
        method(data);
      } else {
        resultMessage = "Failed to execute action, method or data is missing";
      }
    } catch (error) {
      resultMessage = `Failed to execute action: ${error}`;
    }

    return resultMessage;
  }
}

export default Utils;
