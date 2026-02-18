import { StringEmpty } from "./CommonConst";

class StringUtils {
  public static isEmpty(sourceString: string | null | undefined): boolean {
    return sourceString === null || sourceString === undefined || sourceString === StringEmpty || sourceString.length === 0;
  }
}

export default StringUtils;
