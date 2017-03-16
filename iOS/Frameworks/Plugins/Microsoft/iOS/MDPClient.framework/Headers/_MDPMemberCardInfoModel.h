//
//  _MDPMemberCardInfoModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPMemberCardInfoModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPMemberCardInfoModelAttributes {
	__unsafe_unretained NSString *cardType;
	__unsafe_unretained NSString *isDelegate;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *picture;
	__unsafe_unretained NSString *promotionQR;
} MDPMemberCardInfoModelAttributes;

extern const struct MDPMemberCardInfoModelRelationships {
	__unsafe_unretained NSString *seatInfo;
} MDPMemberCardInfoModelRelationships;

@class MDPMemberSeatInfoModel;

@interface _MDPMemberCardInfoModel : NSManagedObject

@property (nonatomic, strong) NSNumber* cardType;

@property (atomic) uint16_t cardTypeValue;
- (uint16_t)cardTypeValue;
- (void)setCardTypeValue:(uint16_t)value_;

//- (BOOL)validateCardType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* isDelegate;

@property (atomic) BOOL isDelegateValue;
- (BOOL)isDelegateValue;
- (void)setIsDelegateValue:(BOOL)value_;

//- (BOOL)validateIsDelegate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSData* picture;

//- (BOOL)validatePicture:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSData* promotionQR;

//- (BOOL)validatePromotionQR:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *seatInfo;

- (NSMutableSet*)seatInfoSet;

@end

@interface _MDPMemberCardInfoModel (SeatInfoCoreDataGeneratedAccessors)
- (void)addSeatInfo:(NSSet*)value_;
- (void)removeSeatInfo:(NSSet*)value_;
- (void)addSeatInfoObject:(MDPMemberSeatInfoModel*)value_;
- (void)removeSeatInfoObject:(MDPMemberSeatInfoModel*)value_;
@end

@interface _MDPMemberCardInfoModel (CoreDataGeneratedPrimitiveAccessors)

- (NSNumber*)primitiveCardType;
- (void)setPrimitiveCardType:(NSNumber*)value;

- (uint16_t)primitiveCardTypeValue;
- (void)setPrimitiveCardTypeValue:(uint16_t)value_;

- (NSNumber*)primitiveIsDelegate;
- (void)setPrimitiveIsDelegate:(NSNumber*)value;

- (BOOL)primitiveIsDelegateValue;
- (void)setPrimitiveIsDelegateValue:(BOOL)value_;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSData*)primitivePicture;
- (void)setPrimitivePicture:(NSData*)value;

- (NSData*)primitivePromotionQR;
- (void)setPrimitivePromotionQR:(NSData*)value;

- (NSMutableSet*)primitiveSeatInfo;
- (void)setPrimitiveSeatInfo:(NSMutableSet*)value;

@end
