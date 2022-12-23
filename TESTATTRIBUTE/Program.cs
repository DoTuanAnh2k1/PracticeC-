namespace TESTATTRIBUTE
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Student student= new Student();
            student.Name = "Nguyen Ha";
            student.Age = 21;
            student.PhoneNumber = "abc";
            student.Email = "nguyenhonghachinh207@gmail.com";

            var result = ValidatorService.Validate(student);
            foreach (var key in result.Keys)
            {
                var value = result[key];
                foreach (var e in value)
                {
                    Console.WriteLine( key + " " + e);
                }
            }
            Console.ReadKey();
        }
    }
}