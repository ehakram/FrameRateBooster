namespace ToolBuddy.FrameRateBooster.Optimizations
{
    struct Matrix4x4
    {
        //TODO Matrix4x4
        //public Vector4 GetColumn(int index)
        //{
        //    switch (index)
        //    {
        //        case 0:
        //            return new Vector4(this.m00, this.m10, this.m20, this.m30);
        //        case 1:
        //            return new Vector4(this.m01, this.m11, this.m21, this.m31);
        //        case 2:
        //            return new Vector4(this.m02, this.m12, this.m22, this.m32);
        //        case 3:
        //            return new Vector4(this.m03, this.m13, this.m23, this.m33);
        //        default:
        //            throw new IndexOutOfRangeException("Invalid column index!");
        //    }
        //}

        //public Vector4 GetRow(int index)
        //{
        //    switch (index)
        //    {
        //        case 0:
        //            return new Vector4(this.m00, this.m01, this.m02, this.m03);
        //        case 1:
        //            return new Vector4(this.m10, this.m11, this.m12, this.m13);
        //        case 2:
        //            return new Vector4(this.m20, this.m21, this.m22, this.m23);
        //        case 3:
        //            return new Vector4(this.m30, this.m31, this.m32, this.m33);
        //        default:
        //            throw new IndexOutOfRangeException("Invalid row index!");
        //    }
        //}

        //public Plane TransformPlane(Plane plane)
        //{
        //    Matrix4x4 inverse = this.inverse;
        //    float num1 = plane.normal.x;
        //    float num2 = plane.normal.y;
        //    float num3 = plane.normal.z;
        //    float distance = plane.distance;
        //    return new Plane(new Vector3((float)((double)inverse.m00 * (double)num1 + (double)inverse.m10 * (double)num2 + (double)inverse.m20 * (double)num3 + (double)inverse.m30 * (double)distance), (float)((double)inverse.m01 * (double)num1 + (double)inverse.m11 * (double)num2 + (double)inverse.m21 * (double)num3 + (double)inverse.m31 * (double)distance), (float)((double)inverse.m02 * (double)num1 + (double)inverse.m12 * (double)num2 + (double)inverse.m22 * (double)num3 + (double)inverse.m32 * (double)distance)), (float)((double)inverse.m03 * (double)num1 + (double)inverse.m13 * (double)num2 + (double)inverse.m23 * (double)num3 + (double)inverse.m33 * (double)distance));
        //}
    }
}
