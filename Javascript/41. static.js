class MathUtil{
    static PI = 3.14159;

    static getDiameter(radius)
    {
        return radius * 2;
    }

    static getCircumference(radius)
    {
        return 2 * this.PI * radius;
    }

    static getArea(radius)
    {
        return this.PI * radius * radius;
    }
}

MathUtil.PI;
MathUtil.getDiameter(10);
MathUtil.getCircumference(10);
MathUtil.getArea(10);