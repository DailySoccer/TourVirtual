//
//  _MDPPaidFanCardInfoModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPPaidFanCardInfoModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPPaidFanCardInfoModelAttributes {
	__unsafe_unretained NSString *cardType;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *promotionQR;
	__unsafe_unretained NSString *validFrom;
	__unsafe_unretained NSString *validTo;
} MDPPaidFanCardInfoModelAttributes;

@interface _MDPPaidFanCardInfoModel : NSManagedObject

@property (nonatomic, strong) NSNumber* cardType;

@property (atomic) uint16_t cardTypeValue;
- (uint16_t)cardTypeValue;
- (void)setCardTypeValue:(uint16_t)value_;

//- (BOOL)validateCardType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSData* promotionQR;

//- (BOOL)validatePromotionQR:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* validFrom;

//- (BOOL)validateValidFrom:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* validTo;

//- (BOOL)validateValidTo:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPPaidFanCardInfoModel (CoreDataGeneratedPrimitiveAccessors)

- (NSNumber*)primitiveCardType;
- (void)setPrimitiveCardType:(NSNumber*)value;

- (uint16_t)primitiveCardTypeValue;
- (void)setPrimitiveCardTypeValue:(uint16_t)value_;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSData*)primitivePromotionQR;
- (void)setPrimitivePromotionQR:(NSData*)value;

- (NSDate*)primitiveValidFrom;
- (void)setPrimitiveValidFrom:(NSDate*)value;

- (NSDate*)primitiveValidTo;
- (void)setPrimitiveValidTo:(NSDate*)value;

@end
