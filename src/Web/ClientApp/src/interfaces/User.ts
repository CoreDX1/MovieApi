export type UserRequest = {
  email: string;
  password: string;
};

export type UserResponse = {
  status: number;
  message: string;
  errors: string[];
  validationErrors: string[];
  data: boolean;
  location: string;
};
