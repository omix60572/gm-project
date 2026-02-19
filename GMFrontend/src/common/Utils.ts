class Utils {
  public static isNullOrUndefined(object: any): boolean {
    return object === null || object === undefined;
  }

  public static tryInvoke(method: () => void): string | null {
    let resultMessage: string | null = null;

    try {
      method();
    } catch (error) {
      resultMessage = `Failed to execute action: ${error}`;
    }

    return resultMessage;
  }
}

export default Utils;
