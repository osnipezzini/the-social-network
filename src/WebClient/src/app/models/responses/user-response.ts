import { UUID } from "crypto";

export interface UserResponse {
  id: UUID;
  name: string;
  email: string;
}
