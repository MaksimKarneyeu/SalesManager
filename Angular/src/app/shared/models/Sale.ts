export default class Sale { 
    public id: number;   
    public region: string;
    public country: string;
    public itemType: string;
    public salesChannel: string;
    public orderPriority: string;
    public orderDate: Date;
    public orderID: number;
    public shipDate: Date;
    public unitsSold: number;
    public unitPrice: number;
    public unitCost: number;
    public totalRevenue: number;
    public totalCost: number;
    public totalProfit: number;        
}