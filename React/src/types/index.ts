export interface ICategory{
    categoryId: number;
    categoryName: string;
    description: string;
    picture: string;
}

export interface IProduct {
    productId: number;
    productName: string;
    unitPrice: number;
}

export interface IPageBaseProps{
    path?: string;
}

