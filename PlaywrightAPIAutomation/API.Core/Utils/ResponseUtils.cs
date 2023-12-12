namespace API.Core.Utils
{
    public class ResponseUtils
    {
        public readonly static int CODE_200 = 200;
        public readonly static int CODE_201 = 201;
        public readonly static int CODE_400 = 400;
        public readonly static int CODE_404 = 404;
        public readonly static int CODE_500 = 500;
    }

    public enum ExtractResponseBodyType
    {
        JSON,
        TEXT,
        BODY,
        HEADERS,
        STATUS_CODE,
        STATUS_TEXT,
    }
}