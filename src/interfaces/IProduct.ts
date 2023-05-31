export interface IProduct{
  id:number,
  title:String
  price:number,
  description:String,
  category:String,
  image:string,
  favorite:boolean,
  rating:{
    rate:number,
    count:number
  }
}