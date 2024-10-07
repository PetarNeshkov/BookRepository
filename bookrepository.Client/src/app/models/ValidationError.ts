export interface ValidationError
{
  propertyName : string;
  errorMessage : string;
  attemptedValue ?: any;
  errorCode ?: string;
  severity ?: number;
  formattedMessagePlaceholderValues ?: {
    [key : string] : any;
  };
}
