//
//  _MDPMemberSeatInfoModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPMemberSeatInfoModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPMemberSeatInfoModelAttributes {
	__unsafe_unretained NSString *gate;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *row;
	__unsafe_unretained NSString *seat;
	__unsafe_unretained NSString *seatName;
	__unsafe_unretained NSString *sector;
	__unsafe_unretained NSString *sport;
	__unsafe_unretained NSString *stairs;
	__unsafe_unretained NSString *vomitory;
	__unsafe_unretained NSString *zoneMemberSeatInfo;
	__unsafe_unretained NSString *zoneName;
} MDPMemberSeatInfoModelAttributes;

extern const struct MDPMemberSeatInfoModelRelationships {
	__unsafe_unretained NSString *seatInfoMemberCardInfo;
} MDPMemberSeatInfoModelRelationships;

@class MDPMemberCardInfoModel;

@interface _MDPMemberSeatInfoModel : NSManagedObject

@property (nonatomic, strong) NSString* gate;

//- (BOOL)validateGate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* row;

//- (BOOL)validateRow:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* seat;

//- (BOOL)validateSeat:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* seatName;

//- (BOOL)validateSeatName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* sector;

//- (BOOL)validateSector:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* sport;

@property (atomic) int16_t sportValue;
- (int16_t)sportValue;
- (void)setSportValue:(int16_t)value_;

//- (BOOL)validateSport:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* stairs;

//- (BOOL)validateStairs:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* vomitory;

//- (BOOL)validateVomitory:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* zoneMemberSeatInfo;

//- (BOOL)validateZoneMemberSeatInfo:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* zoneName;

//- (BOOL)validateZoneName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPMemberCardInfoModel *seatInfoMemberCardInfo;

//- (BOOL)validateSeatInfoMemberCardInfo:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPMemberSeatInfoModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveGate;
- (void)setPrimitiveGate:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveRow;
- (void)setPrimitiveRow:(NSString*)value;

- (NSString*)primitiveSeat;
- (void)setPrimitiveSeat:(NSString*)value;

- (NSString*)primitiveSeatName;
- (void)setPrimitiveSeatName:(NSString*)value;

- (NSString*)primitiveSector;
- (void)setPrimitiveSector:(NSString*)value;

- (NSNumber*)primitiveSport;
- (void)setPrimitiveSport:(NSNumber*)value;

- (int16_t)primitiveSportValue;
- (void)setPrimitiveSportValue:(int16_t)value_;

- (NSString*)primitiveStairs;
- (void)setPrimitiveStairs:(NSString*)value;

- (NSString*)primitiveVomitory;
- (void)setPrimitiveVomitory:(NSString*)value;

- (NSString*)primitiveZoneMemberSeatInfo;
- (void)setPrimitiveZoneMemberSeatInfo:(NSString*)value;

- (NSString*)primitiveZoneName;
- (void)setPrimitiveZoneName:(NSString*)value;

- (MDPMemberCardInfoModel*)primitiveSeatInfoMemberCardInfo;
- (void)setPrimitiveSeatInfoMemberCardInfo:(MDPMemberCardInfoModel*)value;

@end
