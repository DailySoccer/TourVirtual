//
//  _MDPPreferredPlayerModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPPreferredPlayerModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPPreferredPlayerModelAttributes {
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *order;
	__unsafe_unretained NSString *playerId;
	__unsafe_unretained NSString *playerName;
	__unsafe_unretained NSString *sport;
} MDPPreferredPlayerModelAttributes;

@interface _MDPPreferredPlayerModel : NSManagedObject

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* order;

@property (atomic) int64_t orderValue;
- (int64_t)orderValue;
- (void)setOrderValue:(int64_t)value_;

//- (BOOL)validateOrder:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* playerId;

//- (BOOL)validatePlayerId:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* playerName;

//- (BOOL)validatePlayerName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* sport;

@property (atomic) uint16_t sportValue;
- (uint16_t)sportValue;
- (void)setSportValue:(uint16_t)value_;

//- (BOOL)validateSport:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPPreferredPlayerModel (CoreDataGeneratedPrimitiveAccessors)

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitiveOrder;
- (void)setPrimitiveOrder:(NSNumber*)value;

- (int64_t)primitiveOrderValue;
- (void)setPrimitiveOrderValue:(int64_t)value_;

- (NSString*)primitivePlayerId;
- (void)setPrimitivePlayerId:(NSString*)value;

- (NSString*)primitivePlayerName;
- (void)setPrimitivePlayerName:(NSString*)value;

- (NSNumber*)primitiveSport;
- (void)setPrimitiveSport:(NSNumber*)value;

- (uint16_t)primitiveSportValue;
- (void)setPrimitiveSportValue:(uint16_t)value_;

@end
