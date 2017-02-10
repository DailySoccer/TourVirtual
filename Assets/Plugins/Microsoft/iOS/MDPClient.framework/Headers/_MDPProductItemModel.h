//
//  _MDPProductItemModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPProductItemModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPProductItemModelAttributes {
	__unsafe_unretained NSString *idItem;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *productType;
	__unsafe_unretained NSString *quantity;
} MDPProductItemModelAttributes;

extern const struct MDPProductItemModelRelationships {
	__unsafe_unretained NSString *storeProductItems;
} MDPProductItemModelRelationships;

@class MDPStoreProductModel;

@interface _MDPProductItemModel : NSManagedObject

@property (nonatomic, strong) NSString* idItem;

//- (BOOL)validateIdItem:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* productType;

@property (atomic) uint16_t productTypeValue;
- (uint16_t)productTypeValue;
- (void)setProductTypeValue:(uint16_t)value_;

//- (BOOL)validateProductType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* quantity;

@property (atomic) int64_t quantityValue;
- (int64_t)quantityValue;
- (void)setQuantityValue:(int64_t)value_;

//- (BOOL)validateQuantity:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPStoreProductModel *storeProductItems;

//- (BOOL)validateStoreProductItems:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPProductItemModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveIdItem;
- (void)setPrimitiveIdItem:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitiveProductType;
- (void)setPrimitiveProductType:(NSNumber*)value;

- (uint16_t)primitiveProductTypeValue;
- (void)setPrimitiveProductTypeValue:(uint16_t)value_;

- (NSNumber*)primitiveQuantity;
- (void)setPrimitiveQuantity:(NSNumber*)value;

- (int64_t)primitiveQuantityValue;
- (void)setPrimitiveQuantityValue:(int64_t)value_;

- (MDPStoreProductModel*)primitiveStoreProductItems;
- (void)setPrimitiveStoreProductItems:(MDPStoreProductModel*)value;

@end
