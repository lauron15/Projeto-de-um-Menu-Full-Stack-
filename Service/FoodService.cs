using Foods.Model;
using Foods.Util;
using Microsoft.EntityFrameworkCore;

namespace Foods.Service
{
    public class FoodService
    {
        public AppDatabase _context; 
        public FoodService(AppDatabase context) { _context = context; }

        public List<Food> listarFoods() { return _context.foods.ToList(); }

        public void PostFood(Food food)
        {
            _context.foods.Add(food);
            _context.SaveChanges();
        }

        public void PutFood(Food food) { 
        _context.foods.Update(food);
        _context.SaveChanges();}
    }

   /* public void DeleteFood(long id)
    {
        var vaga = _context.food.Find(id);
        if (vaga != null)
        {
            _context.food.Remove(Food);
            _context.SaveChanges();
        }
    }*/

}
